using Origin.Data;

namespace Origin
{
	public delegate void ResponseCallbackT<ResponseType>(ResponseType response, OriginErrorT err);
}
