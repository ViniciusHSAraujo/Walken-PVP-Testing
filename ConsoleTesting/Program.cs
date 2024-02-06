using Core;
using OfficeOpenXml;
using System.Collections.Concurrent;

internal class Program
{
    private static void Main(string[] args)
    {
        // Definindo valores mínimos e passo
        const int SCORE = 198;
        const int MINIMUM = 38;
        const int STEP = 1;

        List<(decimal, decimal)> laserPenPossibilities = [
            (0.3m, 0.3m),
            (0.3m, 0.4m),
            (0.3m, 0.5m),
            (0.3m, 0.6m),
            (0.3m, 0.7m),
            (0.3m, 0.8m),
            (0.3m, 0.9m),
            (0.3m, 0.10m),
            (0.3m, 0.11m),
            (0.3m, 0.12m),
            (0.3m, 0.13m),
            (0.3m, 0.14m),
            (0.3m, 0.15m),
            (0.3m, 0.16m),
            (0.3m, 0.17m),
            (0.3m, 0.18m),
            (0.3m, 0.19m),
            (0.3m, 0.20m),
            (0.4m, 0.3m),
            (0.4m, 0.4m),
            (0.4m, 0.5m),
            (0.4m, 0.6m),
            (0.4m, 0.7m),
            (0.4m, 0.8m),
            (0.4m, 0.9m),
            (0.4m, 0.10m),
            (0.4m, 0.11m),
            (0.4m, 0.12m),
            (0.4m, 0.13m),
            (0.4m, 0.14m),
            (0.4m, 0.15m),
            (0.4m, 0.16m),
            (0.4m, 0.17m),
            (0.4m, 0.18m),
            (0.4m, 0.19m),
            (0.4m, 0.20m),
            (0.5m, 0.3m),
            (0.5m, 0.4m),
            (0.5m, 0.5m),
            (0.5m, 0.6m),
            (0.5m, 0.7m),
            (0.5m, 0.8m),
            (0.5m, 0.9m),
            (0.5m, 0.10m),
            (0.5m, 0.11m),
            (0.5m, 0.12m),
            (0.5m, 0.13m),
            (0.5m, 0.14m),
            (0.5m, 0.15m),
            (0.5m, 0.16m),
            (0.5m, 0.17m),
            (0.5m, 0.18m),
            (0.5m, 0.19m),
            (0.5m, 0.20m),
            (0.6m, 0.3m),
            (0.6m, 0.4m),
            (0.6m, 0.5m),
            (0.6m, 0.6m),
            (0.6m, 0.7m),
            (0.6m, 0.8m),
            (0.6m, 0.9m),
            (0.6m, 0.10m),
            (0.6m, 0.11m),
            (0.6m, 0.12m),
            (0.6m, 0.13m),
            (0.6m, 0.14m),
            (0.6m, 0.15m),
            (0.6m, 0.16m),
            (0.6m, 0.17m),
            (0.6m, 0.18m),
            (0.6m, 0.19m),
            (0.6m, 0.20m),
            (0.7m, 0.3m),
            (0.7m, 0.4m),
            (0.7m, 0.5m),
            (0.7m, 0.6m),
            (0.7m, 0.7m),
            (0.7m, 0.8m),
            (0.7m, 0.9m),
            (0.7m, 0.10m),
            (0.7m, 0.11m),
            (0.7m, 0.12m),
            (0.7m, 0.13m),
            (0.7m, 0.14m),
            (0.7m, 0.15m),
            (0.7m, 0.16m),
            (0.7m, 0.17m),
            (0.7m, 0.18m),
            (0.7m, 0.19m),
            (0.7m, 0.20m),
            (0.8m, 0.3m),
            (0.8m, 0.4m),
            (0.8m, 0.5m),
            (0.8m, 0.6m),
            (0.8m, 0.7m),
            (0.8m, 0.8m),
            (0.8m, 0.9m),
            (0.8m, 0.10m),
            (0.8m, 0.11m),
            (0.8m, 0.12m),
            (0.8m, 0.13m),
            (0.8m, 0.14m),
            (0.8m, 0.15m),
            (0.8m, 0.16m),
            (0.8m, 0.17m),
            (0.8m, 0.18m),
            (0.8m, 0.19m),
            (0.8m, 0.20m),
            (0.9m, 0.3m),
            (0.9m, 0.4m),
            (0.9m, 0.5m),
            (0.9m, 0.6m),
            (0.9m, 0.7m),
            (0.9m, 0.8m),
            (0.9m, 0.9m),
            (0.9m, 0.10m),
            (0.9m, 0.11m),
            (0.9m, 0.12m),
            (0.9m, 0.13m),
            (0.9m, 0.14m),
            (0.9m, 0.15m),
            (0.9m, 0.16m),
            (0.9m, 0.17m),
            (0.9m, 0.18m),
            (0.9m, 0.19m),
            (0.9m, 0.20m),
            (0.10m, 0.3m),
            (0.10m, 0.4m),
            (0.10m, 0.5m),
            (0.10m, 0.6m),
            (0.10m, 0.7m),
            (0.10m, 0.8m),
            (0.10m, 0.9m),
            (0.10m, 0.10m),
            (0.10m, 0.11m),
            (0.10m, 0.12m),
            (0.10m, 0.13m),
            (0.10m, 0.14m),
            (0.10m, 0.15m),
            (0.10m, 0.16m),
            (0.10m, 0.17m),
            (0.10m, 0.18m),
            (0.10m, 0.19m),
            (0.10m, 0.20m),
            (0.11m, 0.3m),
            (0.11m, 0.4m),
            (0.11m, 0.5m),
            (0.11m, 0.6m),
            (0.11m, 0.7m),
            (0.11m, 0.8m),
            (0.11m, 0.9m),
            (0.11m, 0.10m),
            (0.11m, 0.11m),
            (0.11m, 0.12m),
            (0.11m, 0.13m),
            (0.11m, 0.14m),
            (0.11m, 0.15m),
            (0.11m, 0.16m),
            (0.11m, 0.17m),
            (0.11m, 0.18m),
            (0.11m, 0.19m),
            (0.11m, 0.20m),
            (0.12m, 0.3m),
            (0.12m, 0.4m),
            (0.12m, 0.5m),
            (0.12m, 0.6m),
            (0.12m, 0.7m),
            (0.12m, 0.8m),
            (0.12m, 0.9m),
            (0.12m, 0.10m),
            (0.12m, 0.11m),
            (0.12m, 0.12m),
            (0.12m, 0.13m),
            (0.12m, 0.14m),
            (0.12m, 0.15m),
            (0.12m, 0.16m),
            (0.12m, 0.17m),
            (0.12m, 0.18m),
            (0.12m, 0.19m),
            (0.12m, 0.20m),
            (0.13m, 0.3m),
            (0.13m, 0.4m),
            (0.13m, 0.5m),
            (0.13m, 0.6m),
            (0.13m, 0.7m),
            (0.13m, 0.8m),
            (0.13m, 0.9m),
            (0.13m, 0.10m),
            (0.13m, 0.11m),
            (0.13m, 0.12m),
            (0.13m, 0.13m),
            (0.13m, 0.14m),
            (0.13m, 0.15m),
            (0.13m, 0.16m),
            (0.13m, 0.17m),
            (0.13m, 0.18m),
            (0.13m, 0.19m),
            (0.13m, 0.20m),
            (0.14m, 0.3m),
            (0.14m, 0.4m),
            (0.14m, 0.5m),
            (0.14m, 0.6m),
            (0.14m, 0.7m),
            (0.14m, 0.8m),
            (0.14m, 0.9m),
            (0.14m, 0.10m),
            (0.14m, 0.11m),
            (0.14m, 0.12m),
            (0.14m, 0.13m),
            (0.14m, 0.14m),
            (0.14m, 0.15m),
            (0.14m, 0.16m),
            (0.14m, 0.17m),
            (0.14m, 0.18m),
            (0.14m, 0.19m),
            (0.14m, 0.20m),
            (0.15m, 0.3m),
            (0.15m, 0.4m),
            (0.15m, 0.5m),
            (0.15m, 0.6m),
            (0.15m, 0.7m),
            (0.15m, 0.8m),
            (0.15m, 0.9m),
            (0.15m, 0.10m),
            (0.15m, 0.11m),
            (0.15m, 0.12m),
            (0.15m, 0.13m),
            (0.15m, 0.14m),
            (0.15m, 0.15m),
            (0.15m, 0.16m),
            (0.15m, 0.17m),
            (0.15m, 0.18m),
            (0.15m, 0.19m),
            (0.15m, 0.20m),
            (0.16m, 0.3m),
            (0.16m, 0.4m),
            (0.16m, 0.5m),
            (0.16m, 0.6m),
            (0.16m, 0.7m),
            (0.16m, 0.8m),
            (0.16m, 0.9m),
            (0.16m, 0.10m),
            (0.16m, 0.11m),
            (0.16m, 0.12m),
            (0.16m, 0.13m),
            (0.16m, 0.14m),
            (0.16m, 0.15m),
            (0.16m, 0.16m),
            (0.16m, 0.17m),
            (0.16m, 0.18m),
            (0.16m, 0.19m),
            (0.16m, 0.20m),
            (0.17m, 0.3m),
            (0.17m, 0.4m),
            (0.17m, 0.5m),
            (0.17m, 0.6m),
            (0.17m, 0.7m),
            (0.17m, 0.8m),
            (0.17m, 0.9m),
            (0.17m, 0.10m),
            (0.17m, 0.11m),
            (0.17m, 0.12m),
            (0.17m, 0.13m),
            (0.17m, 0.14m),
            (0.17m, 0.15m),
            (0.17m, 0.16m),
            (0.17m, 0.17m),
            (0.17m, 0.18m),
            (0.17m, 0.19m),
            (0.17m, 0.20m),
            (0.18m, 0.3m),
            (0.18m, 0.4m),
            (0.18m, 0.5m),
            (0.18m, 0.6m),
            (0.18m, 0.7m),
            (0.18m, 0.8m),
            (0.18m, 0.9m),
            (0.18m, 0.10m),
            (0.18m, 0.11m),
            (0.18m, 0.12m),
            (0.18m, 0.13m),
            (0.18m, 0.14m),
            (0.18m, 0.15m),
            (0.18m, 0.16m),
            (0.18m, 0.17m),
            (0.18m, 0.18m),
            (0.18m, 0.19m),
            (0.18m, 0.20m),
            (0.19m, 0.3m),
            (0.19m, 0.4m),
            (0.19m, 0.5m),
            (0.19m, 0.6m),
            (0.19m, 0.7m),
            (0.19m, 0.8m),
            (0.19m, 0.9m),
            (0.19m, 0.10m),
            (0.19m, 0.11m),
            (0.19m, 0.12m),
            (0.19m, 0.13m),
            (0.19m, 0.14m),
            (0.19m, 0.15m),
            (0.19m, 0.16m),
            (0.19m, 0.17m),
            (0.19m, 0.18m),
            (0.19m, 0.19m),
            (0.19m, 0.20m),
            (0.20m, 0.3m),
            (0.20m, 0.4m),
            (0.20m, 0.5m),
            (0.20m, 0.6m),
            (0.20m, 0.7m),
            (0.20m, 0.8m),
            (0.20m, 0.9m),
            (0.20m, 0.10m),
            (0.20m, 0.11m),
            (0.20m, 0.12m),
            (0.20m, 0.13m),
            (0.20m, 0.14m),
            (0.20m, 0.15m),
            (0.20m, 0.16m),
            (0.20m, 0.17m),
            (0.20m, 0.18m),
            (0.20m, 0.19m),
            (0.20m, 0.20m)
            ];

        List<(int, int, int)> milkBoostPossibilities =
                [
                    (33, 7, 20),
                    (33, 20, 7),
                    (37, 3, 20),
                    (37, 20, 3),
                    (50, 3, 7),
                    (50, 7, 3),
                    (35, 10, 15),
                    (35, 15, 10),
                    (40, 5, 15),
                    (40, 15, 5),
                    (45, 5, 10),
                    (45, 10, 5),
                    (38, 10, 12),
                    (38, 12, 10),
                    (40, 8, 12),
                    (40, 12, 8),
                    (42, 8, 10),
                    (42, 10, 8),
                    (3, 37, 20),
                    (3, 50, 7),
                    (7, 33, 20),
                    (7, 50, 3),
                    (20, 33, 7),
                    (20, 37, 3),
                    (5, 40, 15),
                    (5, 45, 10),
                    (10, 35, 15),
                    (10, 45, 5),
                    (15, 35, 10),
                    (15, 40, 5),
                    (8, 40, 12),
                    (8, 42, 10),
                    (10, 38, 12),
                    (10, 42, 8),
                    (12, 38, 10),
                    (12, 40, 8),
                    (3, 7, 50),
                    (3, 20, 37),
                    (7, 3, 50),
                    (7, 20, 33),
                    (20, 3, 37),
                    (20, 7, 33),
                    (5, 10, 45),
                    (5, 15, 40),
                    (10, 5, 45),
                    (10, 15, 35),
                    (15, 5, 40),
                    (15, 10, 35),
                    (8, 10, 42),
                    (8, 12, 40),
                    (10, 8, 42),
                    (10, 12, 38),
                    (12, 8, 40),
                    (12, 10, 38),
                ];

        var cathletes = new List<Cathlete>(10000);
        var id = 0;
        for (int strength = MINIMUM; strength <= SCORE - 2 * MINIMUM; strength += STEP)
        {
            for (int stamina = MINIMUM; stamina <= SCORE - strength - MINIMUM; stamina += STEP)
            {
                int speed = SCORE - strength - stamina;

                Cathlete cathlete = new Cathlete(id++, strength, stamina, speed);
                cathletes.Add(cathlete);
                Console.WriteLine(cathlete);
            }
        }

        var testedIds = new Dictionary<(int, int), bool>(50000);

        decimal done = 1;
        decimal total = cathletes.Count;
        try
        {
            foreach (var cathlete in cathletes)
            {
                try
                {
                    foreach (Cathlete rival in cathletes)
                    {
                        if (cathlete.Id == rival.Id || testedIds.TryGetValue((rival.Id, cathlete.Id), out _))
                            continue;

                        testedIds.TryAdd((cathlete.Id, rival.Id), true);

                        #region Milk Boost
                        Parallel.ForEach(milkBoostPossibilities, possibility =>
                        {
                            try
                            {
                                var boostedCathlete = ApplyBoost(cathlete, possibility);
                                Parallel.ForEach(milkBoostPossibilities, possibility2 =>
                                {
                                    var boostedRival = ApplyBoost(cathlete, possibility2);

                                    Parallel.ForEach(laserPenPossibilities, x =>
                                    {
                                        #region Urban Run
                                        var cathleteUrbanRunScore = boostedCathlete.UrbanRunScore * (1 - x.Item1);
                                        var rivalUrbanRunScore = boostedRival.UrbanRunScore * (1 - x.Item2);
                                        if (cathleteUrbanRunScore == rivalUrbanRunScore)
                                        {
                                            cathlete.AddTieUrbanRun();
                                            rival.AddTieUrbanRun();
                                        }
                                        else if (cathleteUrbanRunScore > rivalUrbanRunScore)
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
                                        var cathleteMarathonScore = boostedCathlete.MarathonScore * (1 - x.Item1);
                                        var rivalMarathonScore = boostedRival.MarathonScore * (1 - x.Item2);

                                        if (cathleteMarathonScore == rivalMarathonScore)
                                        {
                                            cathlete.AddTieMarathon();
                                            rival.AddTieMarathon();
                                        }
                                        else if (cathleteMarathonScore > rivalMarathonScore)
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
                                        var cathleteSprintScore = boostedCathlete.SprintScore * (1 - x.Item1);
                                        var rivalSprintScore = boostedRival.SprintScore * (1 - x.Item2);

                                        if (boostedCathlete.SprintScore == boostedRival.SprintScore)
                                        {
                                            cathlete.AddTieSprint();
                                            rival.AddTieSprint();
                                        }
                                        else if (boostedCathlete.SprintScore > boostedRival.SprintScore)
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
                                    });
                                    boostedRival = null;
                                });
                                boostedCathlete = null;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("1" + e);
                            }
                        });
                        #endregion

                    };
                    Console.WriteLine($"{done}/{total} - {done++ / total:P2} | Cathlete {cathlete.Id} finished with {cathlete.WinRate:P2} win rate!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("2" + e);
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("3" + e);
        }
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var excel = new ExcelPackage())
        {
            var worksheet = excel.Workbook.Worksheets.Add("Cathletes");

            // Criar cabeçalho
            worksheet.Cells["A1"].Value = "Strength";
            worksheet.Cells["B1"].Value = "Stamina";
            worksheet.Cells["C1"].Value = "Speed";
            worksheet.Cells["D1"].Value = "Win Rate";
            worksheet.Cells["E1"].Value = "Win";
            worksheet.Cells["F1"].Value = "Losses";
            worksheet.Cells["G1"].Value = "Ties";
            worksheet.Cells["H1"].Value = "SprintScore";
            worksheet.Cells["I1"].Value = "UrbanRunScore";
            worksheet.Cells["J1"].Value = "MarathonScore";
            worksheet.Cells["K1"].Value = "WinsSprint";
            worksheet.Cells["L1"].Value = "LossesSprint";
            worksheet.Cells["M1"].Value = "TiesSprint";
            worksheet.Cells["N1"].Value = "WinsUrbanRun";
            worksheet.Cells["O1"].Value = "LossesUrbanRun";
            worksheet.Cells["P1"].Value = "TiesUrbanRun";
            worksheet.Cells["Q1"].Value = "WinsMarathon";
            worksheet.Cells["R1"].Value = "LossesMarathon";
            worksheet.Cells["S1"].Value = "TiesMarathon";

            // Preencher dados

            for (int i = 0; i < cathletes.Count; i++)
            {
                var cathlete = cathletes[i];
                worksheet.Cells[i + 2, 1].Value = cathlete.Strength;
                worksheet.Cells[i + 2, 2].Value = cathlete.Stamina;
                worksheet.Cells[i + 2, 3].Value = cathlete.Speed;
                worksheet.Cells[i + 2, 4].Value = cathlete.WinRate;
                worksheet.Cells[i + 2, 5].Value = cathlete.Wins;
                worksheet.Cells[i + 2, 6].Value = cathlete.Losses;
                worksheet.Cells[i + 2, 7].Value = cathlete.Ties;
                worksheet.Cells[i + 2, 8].Value = cathlete.SprintScore;
                worksheet.Cells[i + 2, 9].Value = cathlete.UrbanRunScore;
                worksheet.Cells[i + 2, 10].Value = cathlete.MarathonScore;
                worksheet.Cells[i + 2, 11].Value = cathlete.WinsSprint;
                worksheet.Cells[i + 2, 12].Value = cathlete.LossesSprint;
                worksheet.Cells[i + 2, 13].Value = cathlete.TieSprint;
                worksheet.Cells[i + 2, 14].Value = cathlete.WinsUrbanRun;
                worksheet.Cells[i + 2, 15].Value = cathlete.LossesUrbanRun;
                worksheet.Cells[i + 2, 16].Value = cathlete.TieUrbanRun;
                worksheet.Cells[i + 2, 17].Value = cathlete.WinsMarathon;
                worksheet.Cells[i + 2, 18].Value = cathlete.LossesMarathon;
                worksheet.Cells[i + 2, 19].Value = cathlete.TieUrbanRun;
            }

            // Salvar arquivo
            excel.SaveAs(new FileInfo(@$"C:\TesteDoVini\walkentestwithdebuff.xlsx"));
        }

        CathleteBoosted ApplyBoost(Cathlete cathlete, (int, int, int) boostValues)
        {
            var boostedCathlete = new CathleteBoosted(
                cathlete.Id,
                cathlete.Strength + cathlete.Strength * (boostValues.Item1 / 100m),
                cathlete.Stamina + cathlete.Stamina * (boostValues.Item2 / 100m),
                cathlete.Speed + cathlete.Speed * (boostValues.Item3 / 100m)
                );
            return boostedCathlete;
        }

        Console.WriteLine("Digite qualquer coisa para fechar!");
        Console.ReadKey();
    }
}