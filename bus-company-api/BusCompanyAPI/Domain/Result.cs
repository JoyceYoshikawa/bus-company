using System.Collections.Generic;

namespace BusCompanyAPI.Domain
{
    public class Result<T>
    {
        public Result()
        {
            this.Success = true;
        }

        protected List<string> _domainErrorMessages = new List<string>();

        public T Content { get; set; }

        public bool Success { get; set; }

        public bool HasException
        { get { return !string.IsNullOrEmpty(this.ExceptionMessage); } }

        public string ExceptionMessage { get; set; }

        public bool HasNotifications
        {
            get { return this._domainErrorMessages.Count > 0; }
        }

        public List<string> DomainNotifications
        {
            get { return _domainErrorMessages; }
            set { _domainErrorMessages = value; }
        }
    }
}
