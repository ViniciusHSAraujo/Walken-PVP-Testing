namespace Core;

public record CathleteBoosted
{
    private const int STEPS = 10000;
    public int Id { get; set; }
    public decimal Strength { get; set; }
    public decimal Stamina { get; set; }
    public decimal Speed { get; set; }

    public decimal SprintScore { get; set; }
    public decimal UrbanRunScore { get; set; }
    public decimal MarathonScore { get; set; }

    public CathleteBoosted(int id, decimal strength, decimal stamina, decimal speed)
    {
        Id = id;
        Strength = strength;
        Stamina = stamina;
        Speed = speed;
        CalculateScores();
    }

    public override string ToString()
    {
        return $"Id: {Id}, Strength: {Strength}, Stamina: {Stamina}, Speed: {Speed}";
    }

    private void CalculateScores()
    {
        const decimal sprintKv = 1.0m;
        const decimal sprintKf = 0.5m;
        const decimal sprintKs = 0.25m;

        const decimal urbanRunKv = 0.5m;
        const decimal urbanRunKf = 1.0m;
        const decimal urbanRunKs = 0.5m;

        const decimal marathonKv = 0.25m;
        const decimal marathonKf = 0.25m;
        const decimal marathonKs = 1.0m;

        // Calculate scores directly using the fixed coefficients
        SprintScore = ((Speed * sprintKv + Strength * sprintKf + Stamina * sprintKs) * 10000 + 2 * STEPS);
        UrbanRunScore = ((Speed * urbanRunKv + Strength * urbanRunKf + Stamina * urbanRunKs) * 10000 + 2 * STEPS);
        MarathonScore = ((Speed * marathonKv + Strength * marathonKf + Stamina * marathonKs) * 10000 + 2 * STEPS);
    }
}
public class Cathlete
{
    private const int STEPS = 10000;
    public int Id { get; set; }
    public decimal Strength { get; set; }
    public decimal Stamina { get; set; }
    public decimal Speed { get; set; }

    public decimal SprintScore { get; set; }
    public decimal UrbanRunScore { get; set; }
    public decimal MarathonScore { get; set; }

    public decimal TieSprint { get; private set; }
    public decimal TieMarathon { get; private set; }
    public decimal TieUrbanRun { get; private set; }

    public decimal WinsSprint { get; private set; }
    public decimal WinsMarathon { get; private set; }
    public decimal WinsUrbanRun { get; private set; }

    public decimal LossesSprint { get; private set; }
    public decimal LossesMarathon { get; private set; }
    public decimal LossesUrbanRun { get; private set; }

    public decimal Wins => WinsSprint + WinsUrbanRun + WinsMarathon;
    public decimal Losses => LossesSprint + LossesUrbanRun + LossesMarathon;
    public decimal Ties => TieSprint + TieUrbanRun + TieMarathon;
    public decimal WinRate => Wins / (Wins + Losses + Ties);

    public Cathlete(int id, decimal strength, decimal stamina, decimal speed)
    {
        Id = id;
        Strength = strength;
        Stamina = stamina;
        Speed = speed;
        CalculateScores();
    }

    public override string ToString()
    {
        return $"Id: {Id}, Strength: {Strength}, Stamina: {Stamina}, Speed: {Speed}";
    }

    private void CalculateScores()
    {
        const decimal sprintKv = 1.0m;
        const decimal sprintKf = 0.5m;
        const decimal sprintKs = 0.25m;

        const decimal urbanRunKv = 0.5m;
        const decimal urbanRunKf = 1.0m;
        const decimal urbanRunKs = 0.5m;

        const decimal marathonKv = 0.25m;
        const decimal marathonKf = 0.25m;
        const decimal marathonKs = 1.0m;

        // Calculate scores directly using the fixed coefficients
        SprintScore = ((Speed * sprintKv + Strength * sprintKf + Stamina * sprintKs) * 10000 + 2 * STEPS);
        UrbanRunScore = ((Speed * urbanRunKv + Strength * urbanRunKf + Stamina * urbanRunKs) * 10000 + 2 * STEPS);
        MarathonScore = ((Speed * marathonKv + Strength * marathonKf + Stamina * marathonKs) * 10000 + 2 * STEPS);

    }

    public void AddWinSprint() => WinsSprint++;
    public void AddWinMarathon() => WinsMarathon++;
    public void AddWinUrbanRun() => WinsUrbanRun++;
    public void AddLossSprint() => LossesSprint++;
    public void AddLossMarathon() => LossesMarathon++;
    public void AddLossUrbanRun() => LossesUrbanRun++;
    public void AddTieSprint() => TieSprint++;
    public void AddTieMarathon() => TieMarathon++;
    public void AddTieUrbanRun() => TieUrbanRun++;
}
