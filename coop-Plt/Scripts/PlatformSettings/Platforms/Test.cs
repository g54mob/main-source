namespace Platforms
{
	[Cert(new TRC[] { TRC.R5001 })]
	internal class Test
	{
		[Cert(new TRC[] { TRC.R5005 })]
		internal void Method()
		{
		}
	}
}
