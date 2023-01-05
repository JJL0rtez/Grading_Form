# Grading Form

# Vision Statement
  This form will easily and quickly facilitate the recording, saving, and exporting of individual students grading assessments.
  
# Product Features
- User can add, edit, delete and view each student and their saved data.
  - Data includes:
    - first and last name
    - belt level
    - previous grading data
- Users can create new gradings
  - Needed user input:
    - Grading name
    - Instructor(s)
    - Student(s)
- User can edit an active gradings:
    - Grading name
    - Instructor(s)
    - Student(s)
- Once actively in a grading user can add “grading entries” to current grading
  - Grading entries can reference one or more:
    - Students
    - Techniques
    - Comments (custom or pre-generated)
- User can create complex grading entries via navigation controls on form.
- Form will automatically populate related content as user progress through “grading entries”
  - Example: If user adds a sidekick as the technique the form will populate the selection grid with relevant comments.
- Grading entries will not be saved to current grading until user clicks an add button.
- Date required in database
  - Persons
    - First name
    - Last name
    - Email
    - Belt level
  - Techniques
    - Name
  -  Comments
    - Display Name
    - Description
  - Entries
    - Techniques
    -  Comments
    - Persons
  - TechniqueTypes
    - Name 
  - BeltLevels
    - Name
    - Hierarchy -> Integer Higher numbers indicate higher belt levels 
# Future Features
- User can add, edit, delete, and view technique types.
- User can add, edit, delete, and view default comments.
- User can add, edit, delete, and view configuration settings.
- User can export grading reports for specific a student, grading or group of gradings.
- User can automatically email grading reports to each student upon completion of grading.


