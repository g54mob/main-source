using System.Text;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class WorldLabel : EntityMonoBehaviour
{
	[Tooltip("Label to show above the object in the world. Require DescriptionBuffer component on the entity.")]
	public PugText worldLabel;

	private int _visibilityState = -1;

	private byte[] currentUtf8Text;

	private string currentText;

	private float _initTimer = 1f;

	public override void OnOccupied()
	{
		base.OnOccupied();
		_visibilityState = base.world.EntityManager.GetComponentData<ObjectDataCD>(base.entity).amount;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (worldLabel != null)
		{
			UpdateTextLabel();
		}
	}

	private void UpdateTextLabel()
	{
		if (EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, Manager.ecs.ClientWorld))
		{
			return;
		}
		string text = GetName();
		if (text != null)
		{
			if (_initTimer > 0f)
			{
				_initTimer -= Time.deltaTime;
				return;
			}
			GetState();
			UpdateWorldText(text);
		}
	}

	public void UpdateWorldText(string text)
	{
		if (!(worldLabel == null))
		{
			if (_visibilityState == 0)
			{
				text = "";
			}
			if (_visibilityState == 1 && Manager.main.player.GetCurrentInteractableObject() != GetComponentInChildren<InteractableObject>())
			{
				text = "";
			}
			float num = math.clamp(math.round((float)text.Length / 15f), 2.25f, 4f);
			worldLabel.transform.parent.localPosition = new Vector3(0f, num * 0.5f + 5f, -5f);
			worldLabel.Render(text, rewindEffectAnims: false, force: false, activate: false);
		}
	}

	public int GetState()
	{
		_visibilityState = base.world.EntityManager.GetComponentData<ObjectDataCD>(base.entity).amount;
		return _visibilityState;
	}

	public string GetName()
	{
		if (!base.world.EntityManager.HasBuffer<DescriptionBuffer>(base.entity))
		{
			return null;
		}
		DynamicBuffer<DescriptionBuffer> buffer = base.world.EntityManager.GetBuffer<DescriptionBuffer>(base.entity);
		if (AreEqual(currentUtf8Text, buffer))
		{
			return currentText;
		}
		currentUtf8Text = new byte[buffer.Length];
		for (int i = 0; i < currentUtf8Text.Length; i++)
		{
			currentUtf8Text[i] = buffer[i].Value;
		}
		currentText = Encoding.UTF8.GetString(currentUtf8Text);
		return currentText;
	}

	private bool AreEqual(byte[] currentUtf8Text, DynamicBuffer<DescriptionBuffer> newUtf8Text)
	{
		if (currentUtf8Text == null)
		{
			return false;
		}
		if (currentUtf8Text.Length != newUtf8Text.Length)
		{
			return false;
		}
		for (int i = 0; i < currentUtf8Text.Length; i++)
		{
			if (currentUtf8Text[i] != newUtf8Text[i].Value)
			{
				return false;
			}
		}
		return true;
	}
}
