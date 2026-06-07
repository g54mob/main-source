namespace DV
{
	public class KalmanFilter
	{
		public double MesurementNoise { get; set; }

		public double EnvironmentNoize { get; set; }

		public double RealValueToPreviousRealValue { get; set; }

		public double MeasuredToRealValue { get; set; }

		public double State { get; set; }

		public double Covariance { get; set; }

		public KalmanFilter(double mesurementNoize = 0.125, double environmentNoize = 0.1, double RealValueToPreviousRealValue = 1.0, double MeasuredToRealValue = 1.0)
		{
			MesurementNoise = mesurementNoize;
			EnvironmentNoize = environmentNoize;
			this.RealValueToPreviousRealValue = RealValueToPreviousRealValue;
			this.MeasuredToRealValue = MeasuredToRealValue;
		}

		public void Correct(float data)
		{
			State = RealValueToPreviousRealValue * State;
			Covariance = RealValueToPreviousRealValue * Covariance * RealValueToPreviousRealValue + MesurementNoise;
			double num = MeasuredToRealValue * Covariance / (MeasuredToRealValue * Covariance * MeasuredToRealValue + EnvironmentNoize);
			State += num * ((double)data - MeasuredToRealValue * State);
			Covariance = (1.0 - num * MeasuredToRealValue) * Covariance;
		}

		public float FilterValue(float data)
		{
			Correct(data);
			return (float)State;
		}
	}
}
