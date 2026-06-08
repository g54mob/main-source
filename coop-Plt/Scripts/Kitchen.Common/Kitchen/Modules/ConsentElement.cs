using System.Collections.Generic;
using System.Linq;
using Shapes;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ConsentElement : Element
	{
		public enum ConsentMode
		{
			AllRequired = 0,
			AnyRequired = 1
		}

		[Header("Configuration")]
		public float FillSpeed = 1f;

		public float PartialFillSpeed = 0.1f;

		public ConsentMode Mode;

		[SerializeField]
		[Header("References")]
		public Rectangle ProgressBar;

		[SerializeField]
		public ConsentElementTick TickTemplate;

		[SerializeField]
		public Transform TickHolder;

		[Header("State")]
		private Dictionary<int, bool> Consents;

		private float BaseWidth = 3.14f;

		private float Progress;

		private Dictionary<int, bool> ConsentsSwap = new Dictionary<int, bool>();

		public bool IsCompleted { get; private set; }

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(BaseWidth, ProgressBar.Height, 0f));

		public void Attach(Element element, float pad = 0.25f)
		{
			Bounds boundingBox = element.BoundingBox;
			base.transform.localPosition = new Vector3(boundingBox.center.x, boundingBox.min.y - pad, 0f);
			Resize(boundingBox.size.x);
		}

		public void Resize(float width)
		{
			Transform obj = ProgressBar.transform;
			Vector3 localPosition = obj.localPosition;
			localPosition.x += BaseWidth / 2f;
			localPosition.x -= width / 2f;
			obj.localPosition = localPosition;
			BaseWidth = width;
		}

		public void Setup(List<PlayerInputData> pids)
		{
			Consents = new Dictionary<int, bool>();
			foreach (PlayerInputData pid in pids)
			{
				Consents.Add(pid.PlayerID, value: false);
			}
			ProgressBar.Width = 0f;
			UpdateTicks();
		}

		public bool GetConsent(int player_id)
		{
			if (Consents.TryGetValue(player_id, out var value))
			{
				return value;
			}
			return false;
		}

		public void SetPlayers(List<PlayerInputData> pids)
		{
			if (Consents == null)
			{
				Setup(pids);
			}
			ConsentsSwap.Clear();
			foreach (PlayerInputData pid in pids)
			{
				int playerID = pid.PlayerID;
				if (!ConsentsSwap.ContainsKey(playerID))
				{
					if (Consents.TryGetValue(playerID, out var value))
					{
						ConsentsSwap.Add(playerID, value);
					}
					else
					{
						ConsentsSwap.Add(playerID, value: false);
					}
				}
			}
			Dictionary<int, bool> consentsSwap = ConsentsSwap;
			Dictionary<int, bool> consents = Consents;
			Consents = consentsSwap;
			ConsentsSwap = consents;
		}

		public void ClearConsents()
		{
			if (Consents == null)
			{
				return;
			}
			foreach (int item in Consents.Keys.ToList())
			{
				Consents[item] = false;
			}
			UpdateTicks();
		}

		public void SetConsent(int i, bool value)
		{
			if (Consents != null && (!Consents.TryGetValue(i, out var value2) || value2 != value))
			{
				Consents[i] = value;
				UpdateTicks();
			}
		}

		public void SetAllConsents(bool value)
		{
			if (Consents == null)
			{
				return;
			}
			foreach (int item in Consents.Keys.ToList())
			{
				Consents[item] = value;
			}
			UpdateTicks();
		}

		private float GetProgressSpeed()
		{
			if (Consents == null)
			{
				return 0f;
			}
			if (Consents.Count == 0)
			{
				return -1f;
			}
			bool flag = true;
			bool flag2 = false;
			foreach (KeyValuePair<int, bool> consent in Consents)
			{
				flag &= consent.Value;
				flag2 |= consent.Value;
			}
			if (flag)
			{
				return FillSpeed;
			}
			if (flag2 && Mode == ConsentMode.AnyRequired)
			{
				return PartialFillSpeed;
			}
			return 0f;
		}

		private void UpdateBar()
		{
			ProgressBar.Width = BaseWidth * Progress;
		}

		private void UpdateTicks()
		{
			foreach (Transform item in TickHolder)
			{
				Object.Destroy(item.gameObject);
			}
			int num = 0;
			foreach (KeyValuePair<int, bool> consent in Consents)
			{
				if (consent.Value)
				{
					num++;
				}
			}
			Vector3 vector = new Vector3(0.6f, 0f, 0f);
			int num2 = 0;
			foreach (KeyValuePair<int, bool> consent2 in Consents)
			{
				ConsentElementTick consentElementTick = Object.Instantiate(TickTemplate, TickHolder, worldPositionStays: true);
				consentElementTick.transform.localPosition = vector * ((float)(num - 1) * -0.5f) + num2 * vector;
				consentElementTick.gameObject.SetActive(value: true);
				PlayerInfo playerInfo = Players.Main.Get(consent2.Key);
				consentElementTick.Setup(playerInfo.Profile.Colour, playerInfo.Index, consent2.Value);
				if (consent2.Value)
				{
					num2++;
				}
			}
		}

		public void Update()
		{
			float progressSpeed = GetProgressSpeed();
			if (progressSpeed <= 0f)
			{
				Progress -= 2f * Time.unscaledDeltaTime;
			}
			else
			{
				Progress += progressSpeed * Time.unscaledDeltaTime;
			}
			IsCompleted = Progress >= 1f;
			Progress = Mathf.Clamp01(Progress);
			UpdateBar();
		}
	}
}
