using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors
{
	public class AdjustValuePanel : MonoBehaviour
	{
		public delegate void OnValueChange(AdjustValuePanel panel, bool positive);

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private TextMeshProUGUI _ValueText;

		[SerializeField]
		private Button _UpButton;

		[SerializeField]
		private Button _DownButton;

		[SerializeField]
		private float _IncrementAmount;

		[SerializeField]
		private string _Suffix;

		[SerializeField]
		private bool CanGoNegative;

		private float _displayValue;

		private bool _canGoUp;

		private bool _canGoDown;

		private int _pointsAssigned;

		private Color _inactiveColor;

		private Selectable _selectOnRight;

		public event OnValueChange ValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		public void Initialize(int pointsAssigned)
		{
		}

		public void IncrementUp()
		{
		}

		public void SetValue(int v)
		{
		}

		public void IncrementDown()
		{
		}

		public float GetValue()
		{
			return 0f;
		}

		public int GetIncrementValue()
		{
			return 0;
		}

		public void SetCanIncrementUp(bool enabled)
		{
		}

		public void SetCanIncrementDown(bool enabled)
		{
		}

		private void Refresh()
		{
		}

		private bool CanDecrease()
		{
			return false;
		}

		private bool CanIncrease()
		{
			return false;
		}

		public Selectable GetUpButton()
		{
			return null;
		}

		public Selectable GetDownButton()
		{
			return null;
		}
	}
}
