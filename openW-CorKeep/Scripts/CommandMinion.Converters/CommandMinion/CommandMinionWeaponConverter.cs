using Pug.Conversion;

namespace CommandMinion
{
	public class CommandMinionWeaponConverter : SingleAuthoringComponentConverter<CommandMinionWeaponAuthoring>
	{
		protected override void Convert(CommandMinionWeaponAuthoring authoring)
		{
			((Converter)this).EnsureHasComponent<CommandMinionWeaponCD>();
		}
	}
}
