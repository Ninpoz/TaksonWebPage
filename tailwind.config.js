/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Pages/**/*.cshtml',  // Correct path for pages
        './Views/**/*.cshtml',  // Correct path for views
        './node_modules/flowbite/**/*.js',  // Flowbite components
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ],
};
