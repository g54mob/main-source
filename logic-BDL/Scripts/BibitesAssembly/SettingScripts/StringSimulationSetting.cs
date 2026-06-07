namespace SettingScripts
{
	public class StringSimulationSetting : StringSetting
	{
		private string Value;

		public override string val
		{
			get
			{
				return Value;
			}
			set
			{
				Value = value;
			}
		}
	}
}
