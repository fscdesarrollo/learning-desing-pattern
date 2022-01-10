namespace ConsoleApp3
{
    public class CredentialsValidationsError
    {
        public CredentialsValidationsError(string rule, string result)
        {
            Rule = rule;
            Result = result;
        }

        public string Rule { get; set; }
        public string Result { get; set; }
    }
}
