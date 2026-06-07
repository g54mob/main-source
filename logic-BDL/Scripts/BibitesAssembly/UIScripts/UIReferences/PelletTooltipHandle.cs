using SimulationScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class PelletTooltipHandle : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private FloatValueTextHandle amount;

		[SerializeField]
		private FloatValueTextHandle energy;

		[SerializeField]
		private FloatValueTextHandle mass;

		[SerializeField]
		private GameObject freshSection;

		[SerializeField]
		private FloatValueTextHandle freshTime;

		[SerializeField]
		private GameObject decayingSection;

		private MatterPellet targetPellet;

		private bool perishable;

		private bool fresh;

		private bool firstUpdate;

		private LayoutElement layoutElement;

		public int characterWrapLimit = 80;

		public float screenOffset;

		private RectTransform rect;

		private void Awake()
		{
			layoutElement = GetComponent<LayoutElement>();
			rect = GetComponent<RectTransform>();
		}

		public void SetTooltip(MatterPellet pellet)
		{
			targetPellet = pellet;
			(int, float, float) tuple = MatterDecayProcessor.I.SetGetSelection(targetPellet);
			perishable = tuple.Item1 > -1;
			title.text = targetPellet.material.Name;
			UpdateDecayStatus(tuple.Item3 > 0f);
			UpdatePelletInfo();
		}

		public void ResetTooltip()
		{
		}

		private void UpdateDecayStatus(bool val)
		{
			if (!perishable)
			{
				freshSection.SetActive(value: false);
				decayingSection.SetActive(value: false);
			}
			else
			{
				fresh = val;
				freshSection.SetActive(fresh);
				decayingSection.SetActive(!fresh);
			}
		}

		private void UpdatePelletInfo()
		{
			if (targetPellet == null)
			{
				return;
			}
			if (perishable)
			{
				(int index, float decayAmount, float freshTimeRemaining) tuple = MatterDecayProcessor.I.SetGetSelection(targetPellet);
				float item = tuple.decayAmount;
				float item2 = tuple.freshTimeRemaining;
				float num = targetPellet.amount - item;
				amount.SetValue(num);
				energy.SetValue(targetPellet.EnergyDensity * num);
				mass.SetValue(targetPellet.material.MassDensity * num);
				if (fresh)
				{
					if (item2 <= 0f)
					{
						UpdateDecayStatus(val: false);
					}
					else
					{
						freshTime.SetValue(item2);
					}
				}
			}
			else
			{
				amount.SetValue(targetPellet.amount);
				energy.SetValue(targetPellet.energy);
				mass.SetValue(targetPellet.mass);
			}
		}

		public void Update()
		{
			UpdatePelletInfo();
			Vector2 vector = Input.mousePosition;
			float x = ((vector.x > (float)Screen.width / 2f) ? 1f : 0f);
			float y = ((vector.y > (float)Screen.height / 2f) ? 1f : 0f);
			float num = 10f * Mathf.Sign(vector.x - (float)Screen.width / 2f);
			float num2 = 10f * Mathf.Sign(vector.y - (float)Screen.height / 2f);
			rect.localPosition = vector - new Vector2((float)Screen.width * screenOffset + num, (float)Screen.height * screenOffset + num2);
			rect.pivot = new Vector2(x, y);
		}
	}
}
