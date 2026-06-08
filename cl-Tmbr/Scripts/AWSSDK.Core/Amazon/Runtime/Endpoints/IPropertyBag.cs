namespace Amazon.Runtime.Endpoints
{
	public interface IPropertyBag
	{
		object this[string propertyName] { get; set; }
	}
}
