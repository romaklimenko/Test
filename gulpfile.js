var gulp = require('gulp');
var shell = require('gulp-shell');

var options = {
  color: 'false'
};

gulp.task('default', ['build', 'run']);

gulp.task('build', shell.task([
	'dnu build Sample/'
]));

gulp.task('run', shell.task([
	'dnx -p Test run "./Sample/bin/Debug/dnx451/Sample.dll"'
]))