using Rewired.Internal;

namespace Rewired.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IElementIdentifierTool
	{
		void Initialize(GUIText guiText);

		void Start();

		void Update();

		void OnDestroy();
	}
}
