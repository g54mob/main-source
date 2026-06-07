using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class ProblemInfoElement : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _message;

		[SerializeField]
		private TextMeshProI18n _detail;

		private GameObjectX.ErrorInfo _problemInfo;

		public GameObjectX.ErrorInfo ProblemInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
