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
        var idFile = DateTime.Now.Ticks;

        List<(decimal, decimal)> laserPenPossibilitiesOld = [
            (0.03m, 0.03m),
            (0.03m, 0.04m),
            (0.03m, 0.05m),
            (0.03m, 0.06m),
            (0.03m, 0.07m),
            (0.03m, 0.08m),
            (0.03m, 0.09m),
            (0.03m, 0.10m),
            (0.03m, 0.11m),
            (0.03m, 0.12m),
            (0.03m, 0.13m),
            (0.03m, 0.14m),
            (0.03m, 0.15m),
            (0.03m, 0.16m),
            (0.03m, 0.17m),
            (0.03m, 0.18m),
            (0.03m, 0.19m),
            (0.03m, 0.20m),
            (0.04m, 0.03m),
            (0.04m, 0.04m),
            (0.04m, 0.05m),
            (0.04m, 0.06m),
            (0.04m, 0.07m),
            (0.04m, 0.08m),
            (0.04m, 0.09m),
            (0.04m, 0.10m),
            (0.04m, 0.11m),
            (0.04m, 0.12m),
            (0.04m, 0.13m),
            (0.04m, 0.14m),
            (0.04m, 0.15m),
            (0.04m, 0.16m),
            (0.04m, 0.17m),
            (0.04m, 0.18m),
            (0.04m, 0.19m),
            (0.04m, 0.20m),
            (0.05m, 0.03m),
            (0.05m, 0.04m),
            (0.05m, 0.05m),
            (0.05m, 0.06m),
            (0.05m, 0.07m),
            (0.05m, 0.08m),
            (0.05m, 0.09m),
            (0.05m, 0.10m),
            (0.05m, 0.11m),
            (0.05m, 0.12m),
            (0.05m, 0.13m),
            (0.05m, 0.14m),
            (0.05m, 0.15m),
            (0.05m, 0.16m),
            (0.05m, 0.17m),
            (0.05m, 0.18m),
            (0.05m, 0.19m),
            (0.05m, 0.20m),
            (0.06m, 0.03m),
            (0.06m, 0.04m),
            (0.06m, 0.05m),
            (0.06m, 0.06m),
            (0.06m, 0.07m),
            (0.06m, 0.08m),
            (0.06m, 0.09m),
            (0.06m, 0.10m),
            (0.06m, 0.11m),
            (0.06m, 0.12m),
            (0.06m, 0.13m),
            (0.06m, 0.14m),
            (0.06m, 0.15m),
            (0.06m, 0.16m),
            (0.06m, 0.17m),
            (0.06m, 0.18m),
            (0.06m, 0.19m),
            (0.06m, 0.20m),
            (0.07m, 0.03m),
            (0.07m, 0.04m),
            (0.07m, 0.05m),
            (0.07m, 0.06m),
            (0.07m, 0.07m),
            (0.07m, 0.08m),
            (0.07m, 0.09m),
            (0.07m, 0.10m),
            (0.07m, 0.11m),
            (0.07m, 0.12m),
            (0.07m, 0.13m),
            (0.07m, 0.14m),
            (0.07m, 0.15m),
            (0.07m, 0.16m),
            (0.07m, 0.17m),
            (0.07m, 0.18m),
            (0.07m, 0.19m),
            (0.07m, 0.20m),
            (0.08m, 0.03m),
            (0.08m, 0.04m),
            (0.08m, 0.05m),
            (0.08m, 0.06m),
            (0.08m, 0.07m),
            (0.08m, 0.08m),
            (0.08m, 0.09m),
            (0.08m, 0.10m),
            (0.08m, 0.11m),
            (0.08m, 0.12m),
            (0.08m, 0.13m),
            (0.08m, 0.14m),
            (0.08m, 0.15m),
            (0.08m, 0.16m),
            (0.08m, 0.17m),
            (0.08m, 0.18m),
            (0.08m, 0.19m),
            (0.08m, 0.20m),
            (0.09m, 0.03m),
            (0.09m, 0.04m),
            (0.09m, 0.05m),
            (0.09m, 0.06m),
            (0.09m, 0.07m),
            (0.09m, 0.08m),
            (0.09m, 0.09m),
            (0.09m, 0.10m),
            (0.09m, 0.11m),
            (0.09m, 0.12m),
            (0.09m, 0.13m),
            (0.09m, 0.14m),
            (0.09m, 0.15m),
            (0.09m, 0.16m),
            (0.09m, 0.17m),
            (0.09m, 0.18m),
            (0.09m, 0.19m),
            (0.09m, 0.20m),
            (0.10m, 0.03m),
            (0.10m, 0.04m),
            (0.10m, 0.05m),
            (0.10m, 0.06m),
            (0.10m, 0.07m),
            (0.10m, 0.08m),
            (0.10m, 0.09m),
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
            (0.11m, 0.03m),
            (0.11m, 0.04m),
            (0.11m, 0.05m),
            (0.11m, 0.06m),
            (0.11m, 0.07m),
            (0.11m, 0.08m),
            (0.11m, 0.09m),
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
            (0.12m, 0.03m),
            (0.12m, 0.04m),
            (0.12m, 0.05m),
            (0.12m, 0.06m),
            (0.12m, 0.07m),
            (0.12m, 0.08m),
            (0.12m, 0.09m),
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
            (0.13m, 0.03m),
            (0.13m, 0.04m),
            (0.13m, 0.05m),
            (0.13m, 0.06m),
            (0.13m, 0.07m),
            (0.13m, 0.08m),
            (0.13m, 0.09m),
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
            (0.14m, 0.03m),
            (0.14m, 0.04m),
            (0.14m, 0.05m),
            (0.14m, 0.06m),
            (0.14m, 0.07m),
            (0.14m, 0.08m),
            (0.14m, 0.09m),
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
            (0.15m, 0.03m),
            (0.15m, 0.04m),
            (0.15m, 0.05m),
            (0.15m, 0.06m),
            (0.15m, 0.07m),
            (0.15m, 0.08m),
            (0.15m, 0.09m),
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
            (0.16m, 0.03m),
            (0.16m, 0.04m),
            (0.16m, 0.05m),
            (0.16m, 0.06m),
            (0.16m, 0.07m),
            (0.16m, 0.08m),
            (0.16m, 0.09m),
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
            (0.17m, 0.03m),
            (0.17m, 0.04m),
            (0.17m, 0.05m),
            (0.17m, 0.06m),
            (0.17m, 0.07m),
            (0.17m, 0.08m),
            (0.17m, 0.09m),
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
            (0.18m, 0.03m),
            (0.18m, 0.04m),
            (0.18m, 0.05m),
            (0.18m, 0.06m),
            (0.18m, 0.07m),
            (0.18m, 0.08m),
            (0.18m, 0.09m),
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
            (0.19m, 0.03m),
            (0.19m, 0.04m),
            (0.19m, 0.05m),
            (0.19m, 0.06m),
            (0.19m, 0.07m),
            (0.19m, 0.08m),
            (0.19m, 0.09m),
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
            (0.20m, 0.03m),
            (0.20m, 0.04m),
            (0.20m, 0.05m),
            (0.20m, 0.06m),
            (0.20m, 0.07m),
            (0.20m, 0.08m),
            (0.20m, 0.09m),
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

        List<(decimal, decimal, decimal)> milkBoostPossibilities =
                [
                    (0.33m, 0.07m, 0.20m),
                    (0.33m, 0.20m, 0.07m),
                    (0.37m, 0.03m, 0.20m),
                    (0.37m, 0.20m, 0.03m),
                    (0.50m, 0.03m, 0.07m),
                    (0.50m, 0.07m, 0.03m),
                    (0.35m, 0.10m, 0.15m),
                    (0.35m, 0.15m, 0.10m),
                    (0.40m, 0.05m, 0.15m),
                    (0.40m, 0.15m, 0.05m),
                    (0.45m, 0.05m, 0.10m),
                    (0.45m, 0.10m, 0.05m),
                    (0.38m, 0.10m, 0.12m),
                    (0.38m, 0.12m, 0.10m),
                    (0.40m, 0.08m, 0.12m),
                    (0.40m, 0.12m, 0.08m),
                    (0.42m, 0.08m, 0.10m),
                    (0.42m, 0.10m, 0.08m),
                    (0.03m, 0.37m, 0.20m),
                    (0.03m, 0.50m, 0.07m),
                    (0.07m, 0.33m, 0.20m),
                    (0.07m, 0.50m, 0.03m),
                    (0.20m, 0.33m, 0.07m),
                    (0.20m, 0.37m, 0.03m),
                    (0.05m, 0.40m, 0.15m),
                    (0.05m, 0.45m, 0.10m),
                    (0.10m, 0.35m, 0.15m),
                    (0.10m, 0.45m, 0.05m),
                    (0.15m, 0.35m, 0.10m),
                    (0.15m, 0.40m, 0.05m),
                    (0.08m, 0.40m, 0.12m),
                    (0.08m, 0.42m, 0.10m),
                    (0.10m, 0.38m, 0.12m),
                    (0.10m, 0.42m, 0.08m),
                    (0.12m, 0.38m, 0.10m),
                    (0.12m, 0.40m, 0.08m),
                    (0.03m, 0.07m, 0.50m),
                    (0.03m, 0.20m, 0.37m),
                    (0.07m, 0.03m, 0.50m),
                    (0.07m, 0.20m, 0.33m),
                    (0.20m, 0.03m, 0.37m),
                    (0.20m, 0.07m, 0.33m),
                    (0.05m, 0.10m, 0.45m),
                    (0.05m, 0.15m, 0.40m),
                    (0.10m, 0.05m, 0.45m),
                    (0.10m, 0.15m, 0.35m),
                    (0.15m, 0.05m, 0.40m),
                    (0.15m, 0.10m, 0.35m),
                    (0.08m, 0.10m, 0.42m),
                    (0.08m, 0.12m, 0.40m),
                    (0.10m, 0.08m, 0.42m),
                    (0.10m, 0.12m, 0.38m),
                    (0.12m, 0.08m, 0.40m),
                    (0.12m, 0.10m, 0.38m),
                ];

        var laserPenPossibilities = new List<(decimal, decimal)>(laserPenPossibilitiesOld.Count);
        foreach (var item in laserPenPossibilitiesOld)
        {
            laserPenPossibilities.Add((1 - item.Item1, 1 - item.Item2));
        }

        var cathletesList = new List<Cathlete>(10000);
        var id = 0;
        for (int strength = MINIMUM; strength <= SCORE - 2 * MINIMUM; strength += STEP)
        {
            for (int stamina = MINIMUM; stamina <= SCORE - strength - MINIMUM; stamina += STEP)
            {
                int speed = SCORE - strength - stamina;

                Cathlete cathlete = new Cathlete(id++, strength, stamina, speed);
                cathletesList.Add(cathlete);
                Console.WriteLine(cathlete);
            }
        }

        var cathletes = new ConcurrentBag<Cathlete>(cathletesList);

        //var testedIds = new ConcurrentDictionary<(int, int), bool>(1000,50000);

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

            decimal done = 0;
            decimal total = cathletes.Count;
            try
            {
                Parallel.ForEach(cathletes, cathlete1 =>
                //foreach (var cathlete in cathletes)
                {
                    try
                    {
                        //Parallel.ForEach(cathletes, rival =>
                        foreach (Cathlete rival in cathletes)
                        {
                            if (rival.Id <= cathlete1.Id)
                                return;

                            #region Milk Boost
                            Parallel.ForEach(milkBoostPossibilities, possibility =>
                            {
                                try
                                {
                                    var boostedCathlete = ApplyBoost(cathlete1, possibility);
                                    Parallel.ForEach(milkBoostPossibilities, possibility2 =>
                                    {
                                        var boostedRival = ApplyBoost(cathlete1, possibility2);

                                        Parallel.ForEach(laserPenPossibilities, x =>
                                        {
                                            #region Urban Run
                                            var cathleteUrbanRunScore = boostedCathlete.UrbanRunScore * x.Item1;
                                            var rivalUrbanRunScore = boostedRival.UrbanRunScore * x.Item2;
                                            if (cathleteUrbanRunScore == rivalUrbanRunScore)
                                            {
                                                cathlete1.AddTieUrbanRun();
                                                rival.AddTieUrbanRun();
                                            }
                                            else if (cathleteUrbanRunScore > rivalUrbanRunScore)
                                            {
                                                cathlete1.AddWinUrbanRun();
                                                rival.AddLossUrbanRun();
                                            }
                                            else
                                            {
                                                rival.AddWinUrbanRun();
                                                cathlete1.AddLossUrbanRun();
                                            }
                                            #endregion
                                            #region Marathon
                                            var cathleteMarathonScore = boostedCathlete.MarathonScore * x.Item1;
                                            var rivalMarathonScore = boostedRival.MarathonScore * x.Item2;

                                            if (cathleteMarathonScore == rivalMarathonScore)
                                            {
                                                cathlete1.AddTieMarathon();
                                                rival.AddTieMarathon();
                                            }
                                            else if (cathleteMarathonScore > rivalMarathonScore)
                                            {
                                                cathlete1.AddWinMarathon();
                                                rival.AddLossMarathon();
                                            }
                                            else
                                            {
                                                rival.AddWinMarathon();
                                                cathlete1.AddLossMarathon();
                                            }
                                            #endregion
                                            #region Sprint
                                            var cathleteSprintScore = boostedCathlete.SprintScore * x.Item1;
                                            var rivalSprintScore = boostedRival.SprintScore * x.Item2;

                                            if (boostedCathlete.SprintScore == boostedRival.SprintScore)
                                            {
                                                cathlete1.AddTieSprint();
                                                rival.AddTieSprint();
                                            }
                                            else if (boostedCathlete.SprintScore > boostedRival.SprintScore)
                                            {
                                                cathlete1.AddWinSprint();
                                                rival.AddLossSprint();
                                            }
                                            else
                                            {
                                                rival.AddWinSprint();
                                                cathlete1.AddLossSprint();
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

                        // Preencher dados

                        var cathlete = cathletes.ElementAt((int)done);
                        worksheet.Cells[(int)done + 2, 1].Value = cathlete.Strength;
                        worksheet.Cells[(int)done + 2, 2].Value = cathlete.Stamina;
                        worksheet.Cells[(int)done + 2, 3].Value = cathlete.Speed;
                        worksheet.Cells[(int)done + 2, 4].Value = cathlete.WinRate;
                        worksheet.Cells[(int)done + 2, 5].Value = cathlete.Wins;
                        worksheet.Cells[(int)done + 2, 6].Value = cathlete.Losses;
                        worksheet.Cells[(int)done + 2, 7].Value = cathlete.Ties;
                        worksheet.Cells[(int)done + 2, 8].Value = cathlete.SprintScore;
                        worksheet.Cells[(int)done + 2, 9].Value = cathlete.UrbanRunScore;
                        worksheet.Cells[(int)done + 2, 10].Value = cathlete.MarathonScore;
                        worksheet.Cells[(int)done + 2, 11].Value = cathlete.WinsSprint;
                        worksheet.Cells[(int)done + 2, 12].Value = cathlete.LossesSprint;
                        worksheet.Cells[(int)done + 2, 13].Value = cathlete.TieSprint;
                        worksheet.Cells[(int)done + 2, 14].Value = cathlete.WinsUrbanRun;
                        worksheet.Cells[(int)done + 2, 15].Value = cathlete.LossesUrbanRun;
                        worksheet.Cells[(int)done + 2, 16].Value = cathlete.TieUrbanRun;
                        worksheet.Cells[(int)done + 2, 17].Value = cathlete.WinsMarathon;
                        worksheet.Cells[(int)done + 2, 18].Value = cathlete.LossesMarathon;
                        worksheet.Cells[(int)done + 2, 19].Value = cathlete.TieUrbanRun;

                        Console.WriteLine($"{done}/{total} - {done++ / total:P2} | Cathlete {cathlete.Id} finished with {cathlete.WinRate:P2} win rate!");

                        // Salvar arquivo
                        excel.SaveAs(new FileInfo(@$"C:\TesteDoVini\walkentestwithdebuff{idFile}.xlsx"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("2" + e);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("3" + e);
            }
        }

        CathleteBoosted ApplyBoost(Cathlete cathlete, (decimal, decimal, decimal) boostValues)
        {
            var boostedCathlete = new CathleteBoosted(
                cathlete.Id,
                cathlete.Strength + cathlete.Strength * boostValues.Item1,
                cathlete.Stamina + cathlete.Stamina * boostValues.Item2,
                cathlete.Speed + cathlete.Speed * boostValues.Item3
                );
            return boostedCathlete;
        }

        Console.WriteLine("Digite qualquer coisa para fechar!");
        Console.ReadKey();
    }
}