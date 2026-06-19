using System;

namespace DevCmdLine
{
	[AttributeUsage(AttributeTargets.Method)]
	public class DevCmdAttribute : Attribute
	{
		public readonly string name;

		public readonly string description;

		public readonly string[] args;

		public DevCmdAttribute(string name, string description, params string[] args)
		{
			this.name = name.ToLower();
			this.description = description;
			if (this.description == null)
			{
				this.description = "";
			}
			if (args != null)
			{
				this.args = new string[args.Length];
				Array.Copy(args, this.args, args.Length);
			}
		}
	}
}
