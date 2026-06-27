using FMODUnity;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "Soldering Tool - Name", menuName = "Restory/Equipment/SolderingTool")]
	public class SolderingToolInfo : ElementCleanerToolInfoBase
	{
		private static class Style
		{
			public const string ToolVfxGroup = "Tool Vfx";
		}

		[SerializeField]
		private Vector2 cursorSize = new Vector2(128f, 128f);

		[SerializeField]
		private ParticleSystem solderingVFX;

		[SerializeField]
		private EventReference toolWorkProcessSoundLoop;

		public override Vector2 CursorSize => cursorSize;

		public ParticleSystem SolderingVFX => solderingVFX;

		public EventReference ToolWorkProcessSoundLoop => toolWorkProcessSoundLoop;
	}
}
