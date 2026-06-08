public class ProfileSettings
{
	public string image;

	public string bio;

	public string rating;

	public string review;

	public string movieReviewed;

	public ProfileSettings(string image, string bio, string rating, string review, string movieReviewed)
	{
		this.image = image;
		this.bio = bio;
		this.rating = rating;
		this.review = review;
		this.movieReviewed = movieReviewed;
	}
}
