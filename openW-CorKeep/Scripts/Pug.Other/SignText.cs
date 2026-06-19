using Pug.Sprite;

public class SignText : WorldLabel
{
	public SpriteObject signWritten;

	public SpriteObject signUnWritten;

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateSprite();
	}

	private void UpdateSprite()
	{
		if (EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, Manager.ecs.ClientWorld))
		{
			return;
		}
		string text = GetName();
		if (text != null)
		{
			if (string.CompareOrdinal(text, "") != 0)
			{
				signWritten.gameObject.SetActive(value: true);
				signWritten.ApplyVisualChange();
				signUnWritten.gameObject.SetActive(value: false);
			}
			else
			{
				signWritten.gameObject.SetActive(value: false);
				signUnWritten.gameObject.SetActive(value: true);
				signUnWritten.ApplyVisualChange();
			}
		}
	}

	public override void OnFree()
	{
		OnPlayerLeft();
		base.OnFree();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		OnPlayerLeft();
		UpdateWorldText("");
	}

	public virtual void Interact()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			bool flag = worldLabel != null && base.world.EntityManager.HasBuffer<DescriptionBuffer>(base.entity);
			player.SetActiveWorldLabel(flag ? this : null);
			Manager.ui.OnSignWindowOpen();
		}
	}

	public void OnPlayerLeft()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && !(player.activeWorldLabel != this))
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
			player.SetActiveWorldLabel(null);
		}
	}
}
