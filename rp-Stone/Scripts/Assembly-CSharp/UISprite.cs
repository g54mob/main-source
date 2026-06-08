using System.Collections.Generic;
using UnityEngine;

public class UISprite : UIControl
{
	private MultilayerSprite sprite;

	private AsciiAnimation anim;

	public override void ResetControl()
	{
		base.ResetControl();
		sprite.source = null;
		sprite.colorOverride = Color.white;
		sprite.pivotX = 0;
		sprite.pivotY = 0;
		sprite.flipX = false;
		sprite.flipY = false;
		sprite.SetFrameIndex(0);
		Width = sprite.width;
		Height = sprite.height;
		anim.Stop();
		anim.playOnStart = false;
		anim.looping = false;
		anim.randomStartTime = false;
		anim.pauseWithGameplay = false;
		anim.duration = 1f;
		for (int i = 0; i < sprite.additionalLayers.Count; i++)
		{
			Object.Destroy(sprite.additionalLayers[i].gameObject);
		}
		sprite.additionalLayers.Clear();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (IsVisibleInHierarchy())
		{
			offsetX += PositionX;
			offsetY += PositionY;
			sprite.Draw(r, offsetX, offsetY);
		}
	}

	public void Load(string spriteData)
	{
		sprite.Load(spriteData);
	}

	public override void Awake()
	{
		sprite = GetComponent<MultilayerSprite>();
		anim = GetComponent<AsciiAnimation>();
		base.Awake();
	}

	[StonescriptNativeMethod("AddLayer")]
	public object Method_AddLayer(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Anim.AddLayer() requires string parameter");
		}
		string sourceText = parameters[0] as string;
		GameObject obj = new GameObject("Layer" + (sprite.additionalLayers.Count + 1));
		obj.transform.parent = base.gameObject.transform;
		AsciiSprite asciiSprite = obj.AddComponent<AsciiSprite>();
		asciiSprite.Load(sourceText);
		sprite.additionalLayers.Add(asciiSprite);
		return obj.AddComponent<SSScriptableObject>();
	}
}
