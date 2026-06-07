using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class CraftableTargetAmountElement : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _amount;

		[SerializeField]
		private Button3DUIView _increaseTargetAmountButton;

		[SerializeField]
		private Button3DUIView _decreaseTargetAmountButton;

		[SerializeField]
		private Button3DUIView _prioritizeButton;

		[SerializeField]
		private Button3DUIView _suspendButton;

		private GameItemCraftableBase _craftable;

		private int _amountStep;

		private LarderSetting _larderSetting;

		private string _originalAmountText;

		public GameItemCraftableBase Craftable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Refresh()
		{
		}

		private void OnEnable()
		{
		}

		private void Awake()
		{
		}

		protected void Start()
		{
		}
	}
}
