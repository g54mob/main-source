namespace ModApi.Craft.Parts.Styles
{
	public interface IPartTextureStyle
	{
		string DetailTextureId { get; }

		string DisplayName { get; }

		string Id { get; }

		string NormalMapTextureId { get; }

		PartTextureStyleOptions Options { get; }
	}
}
