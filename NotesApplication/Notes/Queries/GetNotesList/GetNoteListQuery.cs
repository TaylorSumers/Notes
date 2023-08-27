using MediatR;

namespace NotesApplication.Notes.Queries.GetNotesList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
