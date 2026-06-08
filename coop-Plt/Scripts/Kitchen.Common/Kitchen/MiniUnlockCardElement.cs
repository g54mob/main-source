using Kitchen.Modules;
using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class MiniUnlockCardElement : Element
	{
		public Unlock DefaultUnlock;

		public TextMeshPro Description;

		public Renderer Card;

		private static readonly int TitleParameter = Shader.PropertyToID("_Title");

		public override Bounds BoundingBox
		{
			get
			{
				Vector3 size = Card.bounds.size.XZY();
				return new Bounds(base.transform.localPosition + new Vector3(0f, size.y / 2f, 0f), size);
			}
		}

		private void OnEnable()
		{
			if (DefaultUnlock != null)
			{
				SetUnlock(DefaultUnlock.ID);
				SetUIMode(is_ui_mode: false);
			}
		}

		public void SetUIMode(bool is_ui_mode)
		{
			base.gameObject.SetLayer(LayerMask.NameToLayer(is_ui_mode ? "UI" : "Default"));
		}

		public void SetUnlock(int unlock)
		{
			if (GameData.Main.TryGet<Unlock>(unlock, out var output))
			{
				ICard card = output;
				if (card != null)
				{
					SetUnlock(card);
				}
				else
				{
					Debug.LogError($"Tried to draw a card for {output.name} ({output.ID})");
				}
			}
			else
			{
				Debug.LogError($"Tried to draw a card for {unlock}");
			}
		}

		public void SetUnlock(ICard unlock)
		{
			if (unlock == null)
			{
				Description.text = "";
				return;
			}
			Description.text = unlock.Icon;
			base.MemoryManagerHandle.Register(Card.material).SetColor(TitleParameter, unlock.Colour);
		}
	}
}
