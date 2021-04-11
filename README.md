### C# Web API

Your task is to create an http API that can be consumed by a web app for displaying a list of tasks. Each task has a priority indicating how urgent the task is (1 is most urgent, 10 is least urgent). You must use C# .net core web API (also known as ASP.NET Core) to create the app.
Expected Behaviours:

- There should be an endpoint to add a new task, with a name and a priority of between 1-10.
- There should be an endpoint to list all tasks by the order they were added to the list
- There should be an endpoint to list all tasks ordered by priority
- There should be an endpoint to remove a task
- (Optional) There should be an endpoint to fetch all tasks below a certain priority (e.g. return only tasks with a priority below 3)
