using KitchenData;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class PlayerElement : Element
	{
		public TextMeshPro NameLabel;

		public TextMeshPro UsernameLabel;

		public Renderer Panel;

		public Line JoinBar;

		public RegularPolygon Polygon;

		public bool IsPeerNotPlayer;

		public bool HasBeenPositioned;

		[SerializeField]
		private SwapOutDefaultButtonPrompt PromptSwapper;

		[SerializeField]
		private AnimationCurve MovementCurve;

		private Vector2 AnimationEnd;

		private Vector2 AnimationStart;

		private float AnimationStartTime;

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(Panel.transform.localScale.x, Panel.transform.localScale.y, 0f));

		private void Update()
		{
			if (AnimationStartTime != 0f)
			{
				float time = Time.time - AnimationStartTime;
				float num = MovementCurve.Evaluate(time);
				if (num >= 1f)
				{
					base.Position = AnimationEnd;
					AnimationStartTime = 0f;
				}
				else
				{
					base.Position = AnimationStart + (AnimationEnd - AnimationStart) * num;
				}
			}
		}

		public void MoveAnimated(Vector2 position)
		{
			if (AnimationStartTime == 0f || !((AnimationEnd - position).sqrMagnitude < 0.01f))
			{
				HasBeenPositioned = true;
				AnimationStartTime = Time.time;
				AnimationStart = base.Position;
				AnimationEnd = position;
			}
		}

		public void SetJoinPrompt()
		{
			SetMessage(GameData.Main.GlobalLocalisation["JOIN_PROMPT"]);
			if (Polygon != null)
			{
				Polygon.gameObject.SetActive(value: false);
			}
			SetJoinProgress(0f);
			SetColour(Color.gray);
		}

		public void SetPeer(string name)
		{
			IsPeerNotPlayer = true;
			SetName(name, "");
			SetColour(new Color(0.11764706f, 0.1764706f, 41f / 85f));
			SetJoinProgress(0f);
			if (Polygon != null)
			{
				Polygon.gameObject.SetActive(value: false);
			}
		}

		public void SetPlayer(int id)
		{
			PlayerInfo playerInfo = Players.Main.Get(id);
			IsPeerNotPlayer = false;
			SetName(playerInfo.PrimaryName, playerInfo.SecondaryName);
			SetColour(playerInfo.Profile.Colour);
			SetJoinProgress(playerInfo.JoinProgress);
			PromptSwapper.TargetPlayerIndex = id;
			SetPolygon(playerInfo.Index, playerInfo.Profile.Colour);
		}

		public void SetMessage(string message)
		{
			if (Polygon != null)
			{
				Polygon.gameObject.SetActive(value: false);
			}
			if (NameLabel != null)
			{
				NameLabel.text = message;
			}
			if (UsernameLabel != null)
			{
				UsernameLabel.text = "";
			}
		}

		public void SetName(string row1, string row2)
		{
			if (string.IsNullOrEmpty(row1))
			{
				row1 = "";
			}
			if (NameLabel != null)
			{
				NameLabel.text = row1;
			}
			if (UsernameLabel != null)
			{
				UsernameLabel.text = row2;
			}
		}

		public void SetColour(Color color)
		{
			if (Panel != null)
			{
				base.MemoryManagerHandle.Register(Panel.material).SetColor("_Highlight", color);
			}
		}

		public void SetJoinProgress(float progress)
		{
			if (!(JoinBar == null))
			{
				progress = (progress - PlayerInfoManager.DisplayJoinGrace) / (1f - PlayerInfoManager.DisplayJoinGrace);
				if (progress < 0f)
				{
					JoinBar.gameObject.SetActive(value: false);
					return;
				}
				JoinBar.gameObject.SetActive(value: true);
				JoinBar.End = new Vector3(Mathf.Clamp01(progress), 0f, 0f);
			}
		}

		public void SetPolygon(int sides, Color c)
		{
			if (Polygon != null)
			{
				Polygon.gameObject.SetActive(value: true);
				RegularPolygon polygon = Polygon;
				polygon.Sides = sides switch
				{
					0 => 10, 
					1 => 3, 
					2 => 4, 
					_ => 6, 
				};
				Polygon.Roundness = ((sides == 0) ? 1f : 0.25f);
				Polygon.Radius = ((Polygon.Sides == 3) ? 0.4f : 0.3f);
				Color color = c;
				color.a = 0.75f;
				Polygon.Color = color;
			}
		}
	}
}
