namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	internal class ValidityPreCompInfo : PreCompInfo
	{
		internal static readonly string PRECOMP_NAME;

		private bool failed;

		private bool curveEquationPassed;

		private bool orderPassed;

		internal bool HasFailed()
		{
			return false;
		}

		internal void ReportFailed()
		{
		}

		internal bool HasCurveEquationPassed()
		{
			return false;
		}

		internal void ReportCurveEquationPassed()
		{
		}

		internal bool HasOrderPassed()
		{
			return false;
		}

		internal void ReportOrderPassed()
		{
		}
	}
}
