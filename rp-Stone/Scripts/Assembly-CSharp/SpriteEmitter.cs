using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AsciiParticleEmitter), typeof(AsciiSprite))]
public class SpriteEmitter : MonoBehaviour
{
	public string symbolToEmitFrom;

	public string replacement = "";

	public float offsetX;

	public float offsetY;

	private AsciiParticleEmitter myEmitter;

	private AsciiSprite mySprite;

	private PrewarmEmitter myPrewarm;

	private int lastFrameIndex = -1;

	private Dictionary<int, List<Vector3>> dataDict = new Dictionary<int, List<Vector3>>();

	private void HandleSpriteOnDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (myPrewarm != null)
		{
			myEmitter.FindParticleLayer();
			myPrewarm.DoPrewarm(offsetX, offsetY);
			myPrewarm = null;
		}
		if (lastFrameIndex != mySprite.GetFrameIndex())
		{
			TryToEmit(offsetX, offsetY);
		}
	}

	public void TryToEmit(int x, int y)
	{
		lastFrameIndex = mySprite.GetFrameIndex();
		if (!dataDict.ContainsKey(lastFrameIndex))
		{
			return;
		}
		List<Vector3> list = dataDict[lastFrameIndex];
		for (int i = 0; i < list.Count; i++)
		{
			Vector3 pos = list[i];
			if (mySprite.flipX)
			{
				pos.x = (float)x - pos.x;
			}
			else
			{
				pos.x = (float)x + pos.x;
			}
			if (mySprite.flipY)
			{
				pos.y = (float)y - pos.y;
			}
			else
			{
				pos.y = (float)y + pos.y;
			}
			pos.x += offsetX;
			pos.y += offsetY;
			myEmitter.MoveTo(pos);
			if (myEmitter.particleLayer != null)
			{
				myEmitter.Emit();
			}
		}
	}

	private void PreProcessSymbol()
	{
		if (symbolToEmitFrom == null || symbolToEmitFrom == "" || mySprite.data == null)
		{
			return;
		}
		int num = SpecialSymbols.Map(symbolToEmitFrom[0]);
		int num2 = ((replacement.Length > 0) ? SpecialSymbols.Map(replacement[0]) : (-1));
		for (int i = 0; i < mySprite.data.Pages.Count; i++)
		{
			List<Vector3> list = new List<Vector3>();
			int[][] data = mySprite.data.Pages[i].Data;
			for (int j = 0; j < data.Length; j++)
			{
				for (int k = 0; k < data[j].Length; k++)
				{
					if (data[j][k] == num)
					{
						data[j][k] = num2;
						Vector3 item = new Vector3(j, k, 0f);
						list.Add(item);
					}
				}
			}
			if (list.Count > 0)
			{
				dataDict.Add(i, list);
			}
		}
	}

	private void Awake()
	{
		myEmitter = GetComponent<AsciiParticleEmitter>();
		mySprite = GetComponent<AsciiSprite>();
		myPrewarm = GetComponent<PrewarmEmitter>();
		if (!mySprite.loaded)
		{
			mySprite.Load();
		}
		mySprite.OnDraw += HandleSpriteOnDraw;
		PreProcessSymbol();
	}

	private void OnDestroy()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleSpriteOnDraw;
		}
		myEmitter = null;
		mySprite = null;
		myPrewarm = null;
	}
}
