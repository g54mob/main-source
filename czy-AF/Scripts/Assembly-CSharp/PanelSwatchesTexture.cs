using System.Collections;
using UnityEngine;

public class PanelSwatchesTexture : MonoBehaviour
{
	private Panel panel;

	public static Transform textureList;

	private void Awake()
	{
		panel = Panel.SetTarget(base.transform);
		textureList = Panel.CreateComponent("list", "pages", new Hashtable
		{
			{ "fill", true },
			{
				"template",
				Resources.Load<Transform>("Interface/Prefabs/ItemTexture")
			}
		});
		EventManager.StartListening("ChangeSwatch", DisplayUpdate);
	}

	private void Start()
	{
		Textures.LoadFolder();
	}

	private void DisplayUpdate()
	{
		_ = Swatches.swatch == null;
	}
}
