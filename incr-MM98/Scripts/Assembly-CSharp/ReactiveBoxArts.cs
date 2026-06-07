using R3;
using UnityEngine;

public class ReactiveBoxArts : MonoBehaviour
{
	[SerializeField]
	private ValueStringDisplay gameNameDisplay;

	[SerializeField]
	private BoxArtDisplay gameBoxArtDisplay;

	[SerializeField]
	private ValueStringDisplay sequelNameDisplay;

	[SerializeField]
	private BoxArtDisplay sequelBoxArtDisplay;

	private void Awake()
	{
		Database.State.Game.Name.SubscribeToValueDisplay(gameNameDisplay, 1f);
		Database.State.Sequel.Name.SubscribeToValueDisplay(sequelNameDisplay, 1f);
		Database.State.Game.BoxArt.Select((BoxArt x) => x.TextureGame()).SubscribeToBoxArtDisplay(gameBoxArtDisplay, 1f);
		Database.State.Sequel.BoxArt.Select((BoxArt x) => x.TextureSequel()).SubscribeToBoxArtDisplay(sequelBoxArtDisplay, 1f);
		default(DisposableBag).AddTo(this);
	}
}
