using System.Collections.Generic;

public interface IStyle
{
	string Name { get; }

	bool Match(Selectable s);

	bool Match(MaterialPreviewer.Mode m);

	bool Match(IStyle s);

	void Apply(Selectable s, List<UndoObject.UndoAction> undos);
}
