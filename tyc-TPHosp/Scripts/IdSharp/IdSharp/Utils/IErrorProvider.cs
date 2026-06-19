using System.Windows.Forms;

namespace IdSharp.Utils
{
	public interface IErrorProvider
	{
		void SetError(Control control, string text, ErrorType errorType);

		void ClearError(Control control);
	}
}
