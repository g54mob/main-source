using System.Text;
using I18n;
using TMPro;

namespace Gh.Tk.UI.InfoPanels
{
	public class FightTornadoInfoPanel : GameObjectXInfoPanel
	{
		public ObjectProgressBar3DUIView intensityProgressBar;

		public TextMeshProI18n lifetime;

		public TextMeshPro totalAnger;

		public TextMeshPro security;

		public TextMeshPro damageDone;

		public TextMeshPro soulsTainted;

		public TextMeshProI18n participants;

		private StringBuilder stringBuilder;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public override void Refresh()
		{
		}
	}
}
