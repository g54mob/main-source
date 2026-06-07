namespace BestHTTP
{
	public delegate bool OnStreamingDataDelegate(HTTPRequest request, HTTPResponse response, byte[] dataFragment, int dataFragmentLength);
}
