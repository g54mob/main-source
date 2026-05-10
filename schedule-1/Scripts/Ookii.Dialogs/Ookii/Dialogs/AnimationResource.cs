namespace Ookii.Dialogs
{
	public sealed class AnimationResource
	{
		public string ResourceFile { get; private set; }

		public int ResourceId { get; private set; }

		public AnimationResource(string resourceFile, int resourceId)
		{
		}

		public static AnimationResource GetShellAnimation(ShellAnimation animation)
		{
			return null;
		}

		internal SafeModuleHandle LoadLibrary()
		{
			return null;
		}
	}
}
