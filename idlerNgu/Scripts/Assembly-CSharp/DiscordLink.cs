using UnityEngine;
using UnityEngine.EventSystems;

public class DiscordLink : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public Character character;

	public void discord()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			Application.ExternalEval("window.open(\"https://discord.gg/5revMxD\",\"_blank\")");
		}
		else if (character.platform == platform.Kartridge || character.platform == platform.Steam)
		{
			Application.OpenURL("https://discord.gg/5revMxD");
		}
	}

	public void kartridge()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			Application.ExternalEval("window.open(\"https://www.kartridge.com/games/somethingggg/ngu-idle\",\"_blank\")");
		}
		else if (character.platform == platform.Kartridge || character.platform == platform.Steam)
		{
			Application.OpenURL("https://www.kartridge.com/games/somethingggg/ngu-idle");
		}
	}

	public void steam()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			Application.ExternalEval("window.open(\"https://store.steampowered.com/app/1147690/NGU_IDLE\",\"_blank\")");
		}
		else if (character.platform == platform.Kartridge || character.platform == platform.Steam)
		{
			Application.OpenURL("https://store.steampowered.com/app/1147690/NGU_IDLE");
		}
	}

	public void kong()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			Application.ExternalEval("window.open(\"https://www.kongregate.com/games/somethingggg/ngu-idle\",\"_blank\")");
		}
		else if (character.platform == platform.Kartridge || character.platform == platform.Steam)
		{
			Application.OpenURL("https://www.kongregate.com/games/somethingggg/ngu-idle");
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("Click this to open an invite to NGU's Discord! All the cool kids are doing it, why not you?");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
