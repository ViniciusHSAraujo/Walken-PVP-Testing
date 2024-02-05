namespace Core;
public class Cathlete
{
    private const int STEPS = 10000;
    public int Id { get; set; }
    public int Strength { get; set; }
    public int Stamina { get; set; }
    public int Speed { get; set; }

    public int SprintScore { get; set; }
    public int UrbanRunScore { get; set; }
    public int MarathonScore { get; set; }

    public int WinsSprint { get; private set; }
    public int WinsMarathon { get; private set; }
    public int WinsUrbanRun { get; private set; }

    public int LossesSprint { get; private set; }
    public int LossesMarathon { get; private set; }
    public int LossesUrbanRun { get; private set; }

    public int Wins => WinsSprint + WinsUrbanRun + WinsMarathon;
    public int Losses => LossesSprint + LossesUrbanRun + LossesMarathon;
    public decimal WinRate => (decimal)Wins / ((decimal)Wins + (decimal)Losses) * 100m;

    public Cathlete(int id, int strength, int stamina, int speed)
    {
        Id = id;
        Strength = strength;
        Stamina = stamina;
        Speed = speed;
        CalculateScores();
    }

    public void AddWinSprint() => WinsSprint++;
    public void AddWinMarathon() => WinsMarathon++;
    public void AddWinUrbanRun() => WinsUrbanRun++;
    public void AddLossSprint() => LossesSprint++;
    public void AddLossMarathon() => LossesMarathon++;
    public void AddLossUrbanRun() => LossesUrbanRun++;

    public override string ToString()
    {
        return $"Strength: {Strength}, Stamina: {Stamina}, Speed: {Speed}";
    }

    private void CalculateScores()
    {
        // Define coefficients for each discipline
        var coefficients = new Dictionary<string, (double, double, double)>
        {
            { "Sprint", (1.0, 0.5, 0.25) },
            { "Urban Run", (0.5, 1.0, 0.5) },
            { "Marathon", (0.25, 0.25, 1.0) }
        };

        // Calculate score for each discipline using the formula
        foreach (var discipline in coefficients.Keys)
        {
            var (kv, kf, ks) = coefficients[discipline];
            int score = (int)((Speed * kv + Strength * kf + Stamina * ks) * 10000 + 2 * STEPS); // Assuming 10000 steps

            switch (discipline)
            {
                case "Sprint":
                    SprintScore = score;
                    break;
                case "Urban Run":
                    UrbanRunScore = score;
                    break;
                case "Marathon":
                    MarathonScore = score;
                    break;
            }
        }
    }
}

//{
//    public class Cathlete
//    {
//        public Cathlete(Rarity rarity, int level)
//        {
//            var totalScore = GetTotalScore(rarity, level);

//            Random random = Random.Shared;
//            var strength = (decimal)random.NextDouble() * (totalScore - 30) + 16; // Valor aleatório entre 16 e totalScore-30
//            var stamina = (decimal)random.NextDouble() * (totalScore - strength - 15) + 16; // Valor aleatório entre 16 e (totalScore - strength - 15)
//            var speed = totalScore - strength - stamina; // A soma dos três deve ser igual a totalScore

//            Strength = strength;
//            Stamina = stamina;
//            Speed = speed;
//        }

//        public decimal Strength { get; set; }
//        public decimal Stamina { get; set; }
//        public decimal Speed { get; set; }
//        public Rarity Rarity { get; set; }
//        //public List<Item> Items { get; set; }
//        public decimal Score => Strength + Stamina + Speed; //+ Items?.Sum(x => x.Score) ?? 0;


//        static decimal CalcularValorNoNivel(decimal totalScoreMax, int level)
//        {
//            // Fórmula: Valor no nível = Valor Máximo * (1 + Taxa de Aumento)^(Nível - 1)
//            var valorNoNivel = (totalScoreMax / 15m) * (1 + (0.1m * level));

//            return valorNoNivel;
//        }

//        private static decimal GetTotalScore(Rarity rarity, int level)
//        {
//            var totalScore = 0m;
//            switch (rarity)
//            {
//                case Rarity.Common:
//                case Rarity.Uncommon:
//                    switch (level)
//                    {
//                        case 6:
//                            totalScore = 108;
//                            break;
//                        case 7:
//                            totalScore = 126;
//                            break;
//                        case 8:
//                            totalScore = 144;
//                            break;
//                        case 9:
//                            totalScore = 162;
//                            break;
//                        case 10:
//                            totalScore = 180;
//                            break;
//                        case 11:
//                            totalScore = 198;
//                            break;
//                        case 12:
//                            totalScore = 216;
//                            break;
//                        case 13:
//                            totalScore = 234;
//                            break;
//                        case 14:
//                            totalScore = 252;
//                            break;
//                        case 15:
//                            totalScore = 270;
//                            break;
//                    }
//                    break;
//                case Rarity.Rare:
//                    switch (level)
//                    {
//                        case 6:
//                            totalScore = 114;
//                            break;
//                        case 7:
//                            totalScore = 136.5m;
//                            break;
//                        case 8:
//                            totalScore = 156;
//                            break;
//                        case 9:
//                            totalScore = 175.5m;
//                            break;
//                        case 10:
//                            totalScore = 205;
//                            break;
//                        case 11:
//                            totalScore = 214.5m;
//                            break;
//                        case 12:
//                            totalScore = 240;
//                            break;
//                        case 13:
//                            totalScore = 266.5m;
//                            break;
//                        case 14:
//                            totalScore = 280;
//                            break;
//                        case 15:
//                            totalScore = 300;
//                            break;
//                    }
//                    break;
//                case Rarity.Epic:
//                    switch (level)
//                    {
//                        case 6:
//                            totalScore = 120;
//                            break;
//                        case 7:
//                            totalScore = 136.5m;
//                            break;
//                        case 8:
//                            totalScore = 172;
//                            break;
//                        case 9:
//                            totalScore = 189;
//                            break;
//                        case 10:
//                            totalScore = 240;
//                            break;
//                        case 11:
//                            totalScore = 253;
//                            break;
//                        case 12:
//                            totalScore = 276;
//                            break;
//                        case 13:
//                            totalScore = 292.5m;
//                            break;
//                        case 14:
//                            totalScore = 308;
//                            break;
//                        case 15:
//                            totalScore = 352.5m;
//                            break;
//                    }
//                    break;
//                case Rarity.Legendary:
//                    switch (level)
//                    {
//                        case 6:
//                            totalScore = 123;
//                            break;
//                        case 7:
//                            totalScore = 136.5m;
//                            break;
//                        case 8:
//                            totalScore = 160;
//                            break;
//                        case 9:
//                            totalScore = 189;
//                            break;
//                        case 10:
//                            totalScore = 235;
//                            break;
//                        case 11:
//                            totalScore = 247.5m;
//                            break;
//                        case 12:
//                            totalScore = 306;
//                            break;
//                        case 13:
//                            totalScore = 325;
//                            break;
//                        case 14:
//                            totalScore = 343;
//                            break;
//                        case 15:
//                            totalScore = 390;
//                            break;
//                    }
//                    break;
//                default:
//                    break;
//            }

//            return totalScore;
//        }
//    }

//    public class Item
//    {
//        public decimal Strength { get; set; }
//        public decimal Stamina { get; set; }
//        public decimal Speed { get; set; }
//        public decimal Score => Strength + Stamina + Speed;
//    }

//    public enum Rarity
//    {
//        Common,
//        Uncommon,
//        Rare,
//        Epic,
//        Legendary
//    }
//}
