namespace CRUD.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string Tipo { get; set; }
        public string Error { get; set; }
    }
    public class ServiceResponse<T> : BaseResponse
    {
        public new T Data { get; set; }
    }
}
