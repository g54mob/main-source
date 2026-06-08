using Bindito.Core;
using Timberborn.TemplateInstantiation;

namespace Timberborn.CharactersGame
{
	[Context("Game")]
	internal class CharactersGameConfigurator : Configurator
	{
		protected override void Configure()
		{
			Bind<CharacterBirthNotifier>().AsTransient();
			MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
		}

		private static TemplateModule ProvideTemplateModule()
		{
			TemplateModule.Builder builder = new TemplateModule.Builder();
			builder.AddDecorator<CharacterBirthNotifierSpec, CharacterBirthNotifier>();
			return builder.Build();
		}
	}
}
