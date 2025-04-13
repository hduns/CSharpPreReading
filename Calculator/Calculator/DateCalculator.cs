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

}
