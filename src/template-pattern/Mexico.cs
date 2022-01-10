using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Mexico : Template
    {

        public void EvalAlias(string password, string alias)
        {            
            base._PasswordRuleValidationError.Add(new CredentialsValidationsError("EvalAlias", "false"));
        }

        public override IEnumerable<CredentialsValidationsError> RunCustomValidation(string password, DateTime? birthDate, string docId, string alias = null)
        {
            this.EvalAlias(password, alias);
            return _PasswordRuleValidationError;
        }

    }
}
