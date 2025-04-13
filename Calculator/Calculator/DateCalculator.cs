namespace Calculator;

public class DateCalculator
{
    private DateTime OriginalDate
    {
        get;
        set;
    }
    
    public DateTime NewDate
    {
        get;
        private set;
    }

    private int UserDays
    {
        get;
        set;
    }
    
    private int UserMonths
    {
        get;
        set;
    }
    
    private int UserYears
    {
        get;
        set;
    }

    public DateCalculator(DateTime originalDate, int usersDays, int userMonths, int userYears)
    {
        OriginalDate = originalDate;
        NewDate = originalDate;
        UserDays = usersDays;
        UserMonths = userMonths;
        UserYears = userYears;
    }

    public void Add()
    {
        NewDate = NewDate.AddDays(UserDays);
        NewDate = NewDate.AddMonths(UserMonths);
        NewDate = NewDate.AddYears(UserYears);
    }
    
    public void Subtract()
    {
        NewDate = NewDate.AddDays(-UserDays);
        NewDate = NewDate.AddMonths(-UserMonths);
        NewDate= NewDate.AddYears(-UserYears);
    }

    public void LogCalculationInTextFile(string path, string dateCalculationOption)
    {
        string calculationBody = "";
        string operation = "";

        switch (dateCalculationOption)
        {
            case "Add":
                operation = "+";
                break;
            case "Subtract":
                operation = "-";
                break;
            default:
                break;
        }

        if (UserDays > 0)
        {
            calculationBody += operation + " " + UserDays.ToString() + " day(s)";
        }
        
        if (UserMonths > 0)
        {
            calculationBody += " " + operation + " "  + UserMonths.ToString() + " month(s)";
        }
        
        if (UserYears > 0)
        {
            calculationBody += " " + operation + " "  + UserYears.ToString() + " year(s)";
        }

        calculationBody = calculationBody.Trim();
         

        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine($"{OriginalDate.ToShortDateString()} {calculationBody} = {NewDate.ToShortDateString()}");
            sw.WriteLine();
        }
    }


}
