namespace UniGLTF
{
	public class UniGLTFNotSupportedException : UniGLTFException
	{
		public UniGLTFNotSupportedException(string fmt, params object[] args)
			: this(string.Format(fmt, args))
		{
		}

		public UniGLTFNotSupportedException(string msg)
			: base(msg)
		{
		}
	}
}
