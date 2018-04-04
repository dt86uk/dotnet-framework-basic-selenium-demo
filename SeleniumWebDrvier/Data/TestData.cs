using System.IO;

namespace SeleniumWebDrvier.Data
{
    public class TestData
    {
        public readonly string WebsiteUrl = "http://www.danielthornton.net";
        public readonly string SeleniumUiTestPage = "/selenium-ui-test.html";
        public readonly string ValidEmailAddress = "your.name@domain.com";
        public readonly string ValidPassword = "12345";
        public readonly string RandomStringGenerator = Path.GetRandomFileName().Replace(".", "");
    }
}
