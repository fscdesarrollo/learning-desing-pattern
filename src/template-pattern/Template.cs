using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    /// <summary>
    /// PARAMETERS: Password, BirthDate, DocId, Alias?
    /// </summary>
    public abstract class Template
    {

        protected List<CredentialsValidationsError> _PasswordRuleValidationError;

        /// <summary>
        /// First digits of Personal identification
        /// </summary>
        public void EvalFirstDigitaPersonalIdentification(string password, string docId)
        {

            _PasswordRuleValidationError.Add(new CredentialsValidationsError("EvalFirstDigitaPersonalIdentification", "true"));

        }

        /// <summary>
        ///  Date of birth (1) (D = day, M = month, A = year)
        /// </summary>
        public void EvalBrithDate(string password, DateTime? birthDate)
        {
            _PasswordRuleValidationError.Add(new CredentialsValidationsError("EvalBrithDate", "true"));
        }

        /// <summary>
        /// 3 digit repetition (2)
        /// </summary>
        public void EvalConsecutiveDigitRepetition(string password)
        {
            _PasswordRuleValidationError.Add(new CredentialsValidationsError("EvalConsecutiveDigitRepetition", "false"));
        }

        /// <summary>
        ///  3 digit sequential (3)
        /// </summary>
        public void EvalSequentialDigit(string password)
        {
            _PasswordRuleValidationError.Add(new CredentialsValidationsError("EvalSequentialDigit", "true"));
        }

        /// <summary>
        /// Repeated Pair (4)
        /// </summary>
        public void EvalRepeatedPair(string password)
        {
            _PasswordRuleValidationError.Add(new CredentialsValidationsError("EvalRepeatedPair", "false"));
        }

        public virtual IEnumerable<CredentialsValidationsError> RunCustomValidation(string password, DateTime? birthDate, string docId, string alias = null)
        {
            return _PasswordRuleValidationError;
        }

        public IEnumerable<CredentialsValidationsError> RunValidation(string password, DateTime? birthDate, string docId, string alias = null)
        {
            this.RunPasswordValidation(password, birthDate, docId, alias);
            this.RunCustomValidation(password, birthDate, docId, alias);

            return _PasswordRuleValidationError;
        }

        private IEnumerable<CredentialsValidationsError> RunPasswordValidation(string password, DateTime? birthDate, string docId, string alias = null)
        {
            _PasswordRuleValidationError = new List<CredentialsValidationsError>();

            this.EvalFirstDigitaPersonalIdentification(password, docId);
            this.EvalBrithDate(password, birthDate);
            this.EvalConsecutiveDigitRepetition(password);
            this.EvalSequentialDigit(password);
            this.EvalRepeatedPair(password);

            return _PasswordRuleValidationError;
        }
    }
}