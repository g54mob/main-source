using System.Net;

public class RequestState
{
	public WebRequest webRequest;

	public WebResponse webResponse;

	public string errorMessage;

	public RequestState()
	{
		webRequest = null;
		webResponse = null;
		errorMessage = null;
	}
}
