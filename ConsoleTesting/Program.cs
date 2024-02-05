using Core;
using OfficeOpenXml;

// Definindo valores mínimos e passo
const int minimo = 10;
const int passo = 1;

var cathletes = new List<Cathlete>(10000);
var id = 0;
for (int strength = minimo; strength <= 198 - 2 * minimo; strength += passo)
{
    for (int stamina = minimo; stamina <= 198 - strength - minimo; stamina += passo)
    {
        int speed = 198 - strength - stamina;

        Cathlete cathlete = new Cathlete(id++, strength, stamina, speed);
        cathletes.Add(cathlete);
        Console.WriteLine(cathlete);
    }
}

var testedIds = new Dictionary<(int, int), bool>();

foreach (var cathlete in cathletes)
{
    foreach (var rival in cathletes)
    {
        if (cathlete.Id == rival.Id || testedIds.ContainsKey((cathlete.Id, rival.Id)) || testedIds.ContainsKey((rival.Id, cathlete.Id)))
            continue;

        #region Urban Run
        if (cathlete.UrbanRunScore > rival.UrbanRunScore)
        {
            cathlete.AddWinUrbanRun();
            rival.AddLossUrbanRun();
        }
        else
        {
            rival.AddWinUrbanRun();
            cathlete.AddLossUrbanRun();
        }
        #endregion
        #region Marathon
        if (cathlete.MarathonScore > rival.MarathonScore)
        {
            cathlete.AddWinMarathon();
            rival.AddLossMarathon();
        }
        else
        {
            rival.AddWinMarathon();
            cathlete.AddLossMarathon();
        }
        #endregion
        #region Sprint
        if (cathlete.SprintScore > rival.SprintScore)
        {
            cathlete.AddWinSprint();
            rival.AddLossSprint();
        }
        else
        {
            rival.AddWinSprint();
            cathlete.AddLossSprint();
        }
        #endregion

        testedIds.Add((cathlete.Id, rival.Id), true);
        testedIds.Add((rival.Id, cathlete.Id), true);
    }
}
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

using (var excel = new ExcelPackage())
{
    var worksheet = excel.Workbook.Worksheets.Add("Cathletes");

    // Criar cabeçalho
    worksheet.Cells["A1"].Value = "Strength";
    worksheet.Cells["B1"].Value = "Stamina";
    worksheet.Cells["C1"].Value = "Speed";
    worksheet.Cells["D1"].Value = "SprintScore";
    worksheet.Cells["E1"].Value = "UrbanRunScore";
    worksheet.Cells["F1"].Value = "MarathonScore";
    worksheet.Cells["G1"].Value = "Vitórias";
    worksheet.Cells["H1"].Value = "Derrotas";
    worksheet.Cells["I1"].Value = "Taxa de Vitórias";
    worksheet.Cells["J1"].Value = "WinsSprint";
    worksheet.Cells["K1"].Value = "LossesSprint";
    worksheet.Cells["L1"].Value = "WinsUrbanRun";
    worksheet.Cells["M1"].Value = "LossesUrbanRun";
    worksheet.Cells["N1"].Value = "WinsMarathon";
    worksheet.Cells["O1"].Value = "LossesMarathon";

    // Preencher dados

    for (int i = 0; i < cathletes.Count; i++)
    {
        var cathlete = cathletes[i];
        worksheet.Cells[i + 2, 1].Value = cathlete.Strength;
        worksheet.Cells[i + 2, 2].Value = cathlete.Stamina;
        worksheet.Cells[i + 2, 3].Value = cathlete.Speed;
        worksheet.Cells[i + 2, 4].Value = cathlete.SprintScore;
        worksheet.Cells[i + 2, 5].Value = cathlete.UrbanRunScore;
        worksheet.Cells[i + 2, 6].Value = cathlete.MarathonScore;
        worksheet.Cells[i + 2, 7].Value = cathlete.Wins;
        worksheet.Cells[i + 2, 8].Value = cathlete.Losses;
        worksheet.Cells[i + 2, 9].Value = cathlete.WinRate;
        worksheet.Cells[i + 2, 10].Value = cathlete.WinsSprint;
        worksheet.Cells[i + 2, 11].Value = cathlete.LossesSprint;
        worksheet.Cells[i + 2, 12].Value = cathlete.WinsUrbanRun;
        worksheet.Cells[i + 2, 13].Value = cathlete.LossesUrbanRun;
        worksheet.Cells[i + 2, 14].Value = cathlete.WinsMarathon;
        worksheet.Cells[i + 2, 15].Value = cathlete.LossesMarathon;
    }

    // Salvar arquivo
    excel.SaveAs(new FileInfo(@$"D:\Dados\walkentest.xlsx"));
}


Console.ReadLine();
