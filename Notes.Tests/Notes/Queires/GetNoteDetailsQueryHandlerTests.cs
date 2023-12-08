using AutoMapper;
using Notes.Persistence;
using Notes.Tests.Common;
using NotesApplication.Notes.Queries.GetNoteDetails;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Queires
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        public NotesDbContext Context;
        public IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);
            
            // Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("D02C0BC8-76BD-4E56-ABF5-634D0D2F7D0B")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreatedDate.ShouldBe(DateTime.Today);
        }
    }
}
