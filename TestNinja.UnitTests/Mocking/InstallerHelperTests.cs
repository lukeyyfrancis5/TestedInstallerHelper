using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IFileDownLoader> _fileDownLoader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownLoader = new Mock<IFileDownLoader>();
            _installerHelper = new InstallerHelper(_fileDownLoader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _fileDownLoader.Setup(fd => 
                fd.DownLoadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result =_installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
    }
}
