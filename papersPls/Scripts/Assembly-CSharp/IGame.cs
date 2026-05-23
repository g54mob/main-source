using app.ent;
using app.plat;
using app.vis;
using haxe.lang;

public interface IGame : IHxObject
{
	void update(Input input);

	QuadIter draw();

	int width();

	int height();

	int subpixelCount();

	Image phantomCursorImage();

	Image deviceTestMaskImage();

	bool wantSoak();

	PlatformKind wantPlatformKind();
}
