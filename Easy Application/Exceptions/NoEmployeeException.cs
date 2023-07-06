namespace Easy_Application.Exceptions;

public class NoEmployeeException : Exception
{
    public  NoEmployeeException(int id) :base($"This employee {id} aint here mate")
    {
    }

}