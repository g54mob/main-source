namespace MathNet.Numerics.Statistics.Mcmc
{
	public delegate double TransitionKernelLn<in T>(T to, T from);
}
