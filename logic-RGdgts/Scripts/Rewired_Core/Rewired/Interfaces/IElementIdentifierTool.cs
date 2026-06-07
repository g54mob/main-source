using Rewired.Internal;

namespace Rewired.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IElementIdentifierTool
	{
		void Initialize(GUIText guiText);

		void Start();

		void Update();

		void OnDestroy();
	}
}
