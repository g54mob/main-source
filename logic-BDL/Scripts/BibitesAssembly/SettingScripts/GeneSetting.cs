using SimulationScripts.BibiteScripts;

namespace SettingScripts
{
	public class GeneSetting : FloatSetting
	{
		public int order;

		public bool isPurelyRelative;

		public BibiteGenes.Genes gene;

		public float span => maxValue - minValue;
	}
}
