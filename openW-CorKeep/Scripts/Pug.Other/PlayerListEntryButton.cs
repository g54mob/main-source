using Pug.UnityExtensions;
using UnityEngine;

public class PlayerListEntryButton : ButtonUIElement
{
	public PlayerListEntry playerListEntry;

	public PlayerListEntryButtonType buttonType;

	public override void OnSelected()
	{
		playerListEntry.listConnectedPlayers.GetScrollWindow().MoveScrollToIncludePosition(playerListEntry.localScrollPosition, playerListEntry.nameText.dimensions.height);
		base.OnSelected();
	}

	public override UIelement GetAdjacentUIElement(Direction.Id dir, Vector3 currentPosition)
	{
		UIelement uIelement = base.GetAdjacentUIElement(dir, currentPosition);
		if (uIelement == null)
		{
			uIelement = playerListEntry.listConnectedPlayers.GetAdjacentUIElement(dir, currentPosition);
			if (uIelement is ListConnectedPlayers listConnectedPlayers && (listConnectedPlayers.players == null || listConnectedPlayers.players.Count == 0))
			{
				uIelement = null;
			}
		}
		return uIelement;
	}

	public void SetButtonColor(Color color)
	{
		foreach (SpriteRenderer item in spritesShownUnpressed)
		{
			item.color = color;
		}
	}
}
